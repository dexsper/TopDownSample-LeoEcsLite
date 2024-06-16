using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Systems
{
    public class UnitFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitComponent, TransformComponent>, Exc<UnitLeaderComponent, MoveCommand>> _unitsFilter = default;
        private readonly EcsPoolInject<TransformComponent> _transformsPool = default;
        private readonly EcsPoolInject<MoveCommand> _moveCommandPool = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _unitsFilter.Value)
            {
                ref var unitComponent = ref _unitsFilter.Pools.Inc1.Get(entity);
                ref var unitTransform = ref _unitsFilter.Pools.Inc2.Get(entity);
                
                if(unitComponent.LeaderId == -1)
                    continue;

                if (!_transformsPool.Value.Has(unitComponent.LeaderId))
                    continue;

                ref var leaderTransform = ref _transformsPool.Value.Get(unitComponent.LeaderId);
                ref var moveCommand = ref _moveCommandPool.Value.Add (entity);

                moveCommand.Direction = (leaderTransform.Value.position - unitTransform.Value.position).normalized;
            }
        }
    }
}