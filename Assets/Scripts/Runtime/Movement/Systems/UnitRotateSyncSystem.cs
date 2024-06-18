using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Movement.Components;

namespace Runtime.Movement.Systems
{
    public class UnitRotateSyncSystem : IEcsRunSystem
    {
        private readonly EcsQuery<UnitComponent, TransformComponent, RotateComponent> _rotateFilter = default;

        private readonly EcsPool<TransformComponent> _transformPool;
        private readonly EcsPool<RotateComponent> _rotatePool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _rotateFilter)
            {
                ref var transformComponent = ref _transformPool.Get(entity);
                ref var rotateComponent = ref _rotatePool.Get(entity);

                transformComponent.Value.eulerAngles = rotateComponent.Value;
            }
        }
    }
}