using System;
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using VContainer.Unity;

namespace Runtime
{
    public class GameEcsRunner : EcsRunner, IInitializable, ITickable, ILateTickable, IFixedTickable, IDisposable
    {
        private readonly bool _worldDebug;

#if UNITY_EDITOR
        private IEcsSystems _editorSystems;
#endif

        public GameEcsRunner(bool worldDebug)
        {
            _worldDebug = worldDebug;
        }

        public override EcsRunner SetWorld(EcsWorld world)
        {
            base.SetWorld(world);

#if UNITY_EDITOR
            if (!_worldDebug)
                return this;

            _editorSystems = new EcsSystems(world);
            _editorSystems
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Init();
#endif

            return this;
        }

        public void Initialize()
        {
            Init();
        }

        public void Tick()
        {
            Update();

#if UNITY_EDITOR
            _editorSystems?.Run();
#endif
        }

        public void LateTick()
        {
            LateUpdate();
        }

        public void FixedTick()
        {
            FixedUpdate();
        }

        protected override void Destroy()
        {
            base.Destroy();

#if UNITY_EDITOR
            _editorSystems?.Destroy();
#endif
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}