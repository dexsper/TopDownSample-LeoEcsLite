using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base;
using Runtime.Movement.Systems;
using VContainer;

namespace Runtime.Movement
{
    public class MovementFeature : BaseFeature, IEcsUpdateFeature, IEcsFixedUpdateFeature
    {
        public MovementFeature(IObjectResolver objectResolver, bool debug) : base(objectResolver, debug)
        {
        }

        public override void SetupUpdateSystems(IEcsSystems systems)
        {
            base.SetupUpdateSystems(systems);
            
            systems.Add(_objectResolver.Resolve<PlayerMovementSystem>());
            systems.Add(_objectResolver.Resolve<UnitRotateSystem>());
            systems.Add(_objectResolver.Resolve<UnitRotateSyncSystem>());
            systems.Add(_objectResolver.Resolve<UnitFollowSystem>());
        }

        public override void SetupFixedUpdateSystems(IEcsSystems systems)
        {
            base.SetupFixedUpdateSystems(systems);
            
            systems.Add(_objectResolver.Resolve<UnitMovementSystem>());
        }
    }
}