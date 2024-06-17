using Components;
using Extensions;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Systems
{
    public sealed class UnitRotateSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitComponent, RotateComponent, RotateSpeed, RotateCommand>> _rotateFilter = default;
        private readonly EcsCustomInject<TimeService> _timeSystem = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _rotateFilter.Value)
            {
                ref var rotateComponent = ref _rotateFilter.Pools.Inc2.Get(entity);
                ref var rotateSpeed = ref _rotateFilter.Pools.Inc3.Get(entity);
                ref var rotateDirection = ref _rotateFilter.Pools.Inc4.Get(entity);

                float rotateAmount = rotateDirection.Value * rotateSpeed.Value * _timeSystem.Value.DeltaTime;
                float rotationY = (rotateComponent.Value.y + rotateAmount) % 360f;
                
                rotateComponent.Value = rotateComponent.Value.With(y: rotationY);
            }
        }
    }
}