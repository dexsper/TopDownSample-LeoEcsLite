using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Input.Components;
using Runtime.Input.Services;

namespace Runtime.Input.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly InputService _inputService;

        private readonly EcsQuery<PlayerComponent>.Exc<RotateCommand> _playerFilter;
        private readonly EcsPool<RotateCommand> _rotateCommandPool = default;

        public PlayerInputSystem(InputService inputService)
        {
            _inputService = inputService;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerFilter)
            {
                ref var rotCommand = ref _rotateCommandPool.Add(entity);
                rotCommand.Value = _inputService.Horizontal;
            }
        }
    }
}