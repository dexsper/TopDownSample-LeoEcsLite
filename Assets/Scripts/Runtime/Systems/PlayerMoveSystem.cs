﻿using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitComponent, PlayerComponent, TransformComponent>, Exc<MoveCommand>> _playerFilter;
        private readonly EcsPoolInject<MoveCommand> _moveCommandPool = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerFilter.Value)
            {
                ref var transformComponent = ref _playerFilter.Pools.Inc3.Get(entity);
                ref var moveCommand = ref _moveCommandPool.Value.Add (entity);

                moveCommand.Direction = transformComponent.Value.forward;
            }    
        }
    }
}