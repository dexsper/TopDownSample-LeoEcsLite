using AleVerDes.LeoEcsLiteZoo;
using Runtime.Base;
using Runtime.Time.Services;
using Runtime.Time.Systems;
using UnityEngine;
using VContainer;

namespace Runtime.Time
{
    [CreateAssetMenu(fileName = "TimeFeature", menuName = "Game/Features/TimeFeature")]
    public class TimeFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<TimeService>(Lifetime.Singleton);
            builder.Register<TimeSystem>(Lifetime.Transient);

            builder.Register<TimeFeature>(Lifetime.Transient).WithParameter(_isDebug);
        }

        public override BaseFeature Get(IObjectResolver objectResolver)
        {
            return objectResolver.Resolve<TimeFeature>();
        }
    }
}