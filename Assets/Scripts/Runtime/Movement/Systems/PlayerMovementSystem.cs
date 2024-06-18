using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Input.Components;
using UnityEngine;

namespace Runtime.Movement.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsQuery<PlayerComponent, UnityObjectRef<Transform>>.Exc<MoveCommand> _playerFilter;

        private readonly EcsPool<MoveCommand> _commandPool = default;
        private readonly EcsPool<UnityObjectRef<Transform>> _transformPool = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerFilter)
            {
                ref var transformComponent = ref _transformPool.Get(entity);
                ref var moveCommand = ref _commandPool.Add(entity);

                moveCommand.Direction = transformComponent.Value.forward;
            }
        }
    }
}