using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Systems
{
    public class UnitRotateSyncSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitComponent, TransformComponent, RotateComponent>> _rotateFilter = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _rotateFilter.Value)
            {
                ref var transformComponent = ref _rotateFilter.Pools.Inc2.Get(entity);
                ref var rotateComponent = ref _rotateFilter.Pools.Inc3.Get(entity);

                transformComponent.Value.eulerAngles = rotateComponent.Value;
            }
        }
    }
}