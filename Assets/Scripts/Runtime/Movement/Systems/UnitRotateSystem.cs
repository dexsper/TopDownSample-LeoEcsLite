using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Input.Components;
using Runtime.Movement.Components;
using Runtime.Time.Services;
using Utils.Extensions;

namespace Runtime.Movement.Systems
{
    public sealed class UnitRotateSystem : IEcsRunSystem
    {
        private readonly EcsQuery<UnitComponent, RotateComponent, RotateSpeed, RotateCommand> _rotateFilter = default;
        
        private readonly EcsPool<RotateSpeed> _speedPool;
        private readonly EcsPool<RotateCommand> _commandPool;
        private readonly EcsPool<RotateComponent> _rotatePool;
        
        private readonly TimeService _timeService;

        public UnitRotateSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _rotateFilter)
            {
                ref var rotateComponent = ref _rotatePool.Get(entity);
                ref var rotateSpeed = ref _speedPool.Get(entity);
                ref var rotateDirection = ref _commandPool.Get(entity);

                var rotateAmount = rotateDirection.Value * rotateSpeed.Value * _timeService.DeltaTime;
                var rotationY = (rotateComponent.Value.y + rotateAmount) % 360f;

                rotateComponent.Value = rotateComponent.Value.With(y: rotationY);
            }
        }
    }
}