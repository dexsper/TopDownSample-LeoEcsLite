using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Input.Components;
using Runtime.Movement.Components;
using UnityEngine;

namespace Runtime.Movement.Systems
{
    public class UnitMovementSystem : IEcsRunSystem
    {
        private readonly EcsQuery<UnitComponent, UnityObjectRef<Rigidbody>, MoveCommand, MoveSpeed> _moveFilter = default;

        private readonly EcsPool<MoveSpeed> _speedPool;
        private readonly EcsPool<MoveCommand> _commandPool;
        private readonly EcsPool<UnityObjectRef<Rigidbody>> _rigidbodiesPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _moveFilter)
            {
                ref var rigidbodyComponent = ref _rigidbodiesPool.Get(entity);
                ref var directionComponent = ref _commandPool.Get(entity);
                ref var speedComponent = ref _speedPool.Get(entity);

                var moveForce = directionComponent.Direction * (speedComponent.Value * 10f);
                rigidbodyComponent.Value.AddForce(moveForce, ForceMode.Force);

                var velocity = rigidbodyComponent.Value.velocity;
                var flatVel = new Vector3(velocity.x, 0f, velocity.z);

                if (!(flatVel.magnitude > speedComponent.Value))
                    return;

                var limitedVel = flatVel.normalized * speedComponent.Value;
                rigidbodyComponent.Value.velocity = new Vector3(limitedVel.x, velocity.y, limitedVel.z);
            }
        }
    }
}