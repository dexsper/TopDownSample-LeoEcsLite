using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Movement.Components;
using UnityEngine;

namespace Runtime.Movement.Systems
{
    public class UnitMovementSystem : IEcsRunSystem
    {
        private readonly EcsQuery<UnitComponent, RigidbodyComponent, MoveCommand, MoveSpeed> _moveFilter = default;

        private readonly EcsPool<RigidbodyComponent> _rigidbodiesPool;
        private readonly EcsPool<MoveCommand> _commandPool;
        private readonly EcsPool<MoveSpeed> _speedPool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _moveFilter)
            {
                ref var rigidbodyComponent = ref _rigidbodiesPool.Get(entity);
                ref var directionComponent = ref _commandPool.Get(entity);
                ref var speedComponent = ref _speedPool.Get(entity);

                Vector3 moveForce = directionComponent.Direction * (speedComponent.Value * 10f);
                rigidbodyComponent.Value.AddForce(moveForce, ForceMode.Force);

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