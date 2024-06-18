using AleVerDes.LeoEcsLiteZoo;
using Runtime.Base;
using Runtime.Movement.Systems;
using UnityEngine;
using VContainer;

namespace Runtime.Movement
{
    [CreateAssetMenu(fileName = "MovementFeature", menuName = "Game/Features/MovementFeature")]
    public class MovementFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PlayerMovementSystem>(Lifetime.Transient);
            builder.Register<UnitFollowSystem>(Lifetime.Transient);
            builder.Register<UnitMovementSystem>(Lifetime.Transient);
            builder.Register<UnitRotateSyncSystem>(Lifetime.Transient);
            builder.Register<UnitRotateSystem>(Lifetime.Transient);

            builder.Register<MovementFeature>(Lifetime.Transient);
        }
        
        public override IEcsFeature Get(IObjectResolver objectResolver)
        {
            return objectResolver.Resolve<MovementFeature>();
        }
    }
}