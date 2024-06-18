using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Movement.Systems;
using VContainer;

namespace Runtime.Movement
{
    public class MovementFeature : IEcsUpdateFeature, IEcsFixedUpdateFeature
    {
        private readonly IObjectResolver _objectResolver;

        public MovementFeature(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void SetupUpdateSystems(IEcsSystems systems)
        {
            systems.Add(_objectResolver.Resolve<PlayerMovementSystem>());
            systems.Add(_objectResolver.Resolve<UnitRotateSystem>());
            systems.Add(_objectResolver.Resolve<UnitRotateSyncSystem>());
            systems.Add(_objectResolver.Resolve<UnitFollowSystem>());
        }

        public void SetupFixedUpdateSystems(IEcsSystems systems)
        {
           systems.Add(_objectResolver.Resolve<UnitMovementSystem>());
        }
    }
}