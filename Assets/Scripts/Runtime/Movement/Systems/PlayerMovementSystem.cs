using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Movement.Components;

namespace Runtime.Movement.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsQuery<PlayerComponent, TransformComponent>.Exc<MoveCommand> _playerFilter;

        private readonly EcsPool<TransformComponent> _transformPool = default;
        private readonly EcsPool<MoveCommand> _moveCommandPool = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerFilter)
            {
                ref var transformComponent = ref _transformPool.Get(entity);
                ref var moveCommand = ref _moveCommandPool.Add(entity);

                moveCommand.Direction = transformComponent.Value.forward;
            }
        }
    }
}