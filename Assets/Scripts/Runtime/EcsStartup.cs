using AB_Utility.FromSceneToEntityConverter;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using Services;
using Systems;
using UnityEngine;

public sealed class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private IEcsSystems _updateSystems;
    private IEcsSystems _fixedUpdateSystems;

    private void Start()
    {
        var timeService = new TimeService();
        var inputService = new InputService();
        
        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);
        _updateSystems
            .Add(new TimeSystem())
            .Add(new InputSystem())
            .DelHere<RotateCommand>()
            .DelHere<MoveCommand>()
            .Add(new PlayerInputSystem())
            .Add(new PlayerMovementSystem())
            .Add(new UnitRotateSystem())
            .Add(new UnitRotateSyncSystem())
            .Add(new UnitFollowSystem())
#if UNITY_EDITOR
            .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
            .Add(new Leopotam.EcsLite.UnityEditor.EcsSystemsDebugSystem())
#endif
            .Inject(timeService, inputService)
            .ConvertScene()
            .Init();

        _fixedUpdateSystems = new EcsSystems(_world);
        _fixedUpdateSystems
            .Add(new UnitMovementSystem())
#if UNITY_EDITOR
            .Add(new Leopotam.EcsLite.UnityEditor.EcsSystemsDebugSystem())
#endif
            .Inject()
            .Init();
    }

    private void Update()
    {
        _updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _fixedUpdateSystems?.Destroy();
        _world?.Destroy();
        _world = null;
    }
}