using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Systems
{
    public class UnitMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitComponent, RigidbodyComponent, MoveCommand, MoveSpeed>> _moveFilter = default;
        private readonly EcsPoolInject<MoveCommand> _moveCommandPool = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _moveFilter.Value)
            {
                ref var rigidbodyComponent = ref _moveFilter.Pools.Inc2.Get(entity);
                ref var directionComponent = ref _moveFilter.Pools.Inc3.Get(entity);
                ref var speedComponent = ref _moveFilter.Pools.Inc4.Get(entity);

                Vector3 moveForce = directionComponent.Direction * (speedComponent.Value * 10f);
                rigidbodyComponent.Value.AddForce(moveForce, ForceMode.Force);
                
                _moveCommandPool.Value.Del(entity);

                Vector3 velocity = rigidbodyComponent.Value.velocity;
                Vector3 flatVel = new Vector3(velocity.x, 0f, velocity.z);

                if (!(flatVel.magnitude > speedComponent.Value))
                    return;

                Vector3 limitedVel = flatVel.normalized * speedComponent.Value;
                rigidbodyComponent.Value.velocity = new Vector3(limitedVel.x, velocity.y, limitedVel.z);
            }
        }
    }
}