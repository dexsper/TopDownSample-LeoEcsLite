using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<PlayerComponent, RotateComponent>, Exc<RotateCommand>> _playerFilter;
        private readonly EcsPoolInject<RotateCommand> _rotateCommandPool = default;

        private readonly EcsCustomInject<InputService> _inputService = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerFilter.Value)
            {
                ref var rotCommand = ref _rotateCommandPool.Value.Add(entity);
                rotCommand.Value = _inputService.Value.Horizontal;
            }
        }
    }
}