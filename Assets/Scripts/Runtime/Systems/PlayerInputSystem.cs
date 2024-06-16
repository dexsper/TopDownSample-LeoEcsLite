using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitComponent, PlayerComponent>, Exc<RotateCommand>> _playerFilter;
        private readonly EcsPoolInject<RotateCommand> _rotateCommandPool = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerFilter.Value)
            {
                ref var rotCommand = ref _rotateCommandPool.Value.Add (entity);
                rotCommand.Value = Input.GetAxisRaw ("Horizontal");
            }
        }
    }
}