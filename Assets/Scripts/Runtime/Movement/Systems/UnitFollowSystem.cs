using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Movement.Components;

namespace Runtime.Movement.Systems
{
    public class UnitFollowSystem : IEcsRunSystem
    {
        private readonly EcsQuery<UnitComponent, TransformComponent>.Exc<UnitLeaderComponent, MoveCommand> _unitsFilter = default;
        
        private readonly EcsWorld _world = default;
        private readonly EcsPool<UnitComponent> _unitsPool = default;
        private readonly EcsPool<TransformComponent> _transformPool = default;
        private readonly EcsPool<MoveCommand> _moveCommandPool = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _unitsFilter)
            {
                ref var unitComponent = ref _unitsPool.Get(entity);
                ref var unitTransform = ref _transformPool.Get(entity);
                
                if(!unitComponent.Leader.Unpack(_world, out int leaderId))
                    continue;

                if (!_transformPool.Has(leaderId))
                    continue;

                ref var leaderTransform = ref _transformPool.Get(leaderId);
                ref var moveCommand = ref _moveCommandPool.Add (entity);

                moveCommand.Direction = (leaderTransform.Value.position - unitTransform.Value.position).normalized;
            }
        }
    }
}