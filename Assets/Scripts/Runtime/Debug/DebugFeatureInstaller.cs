using AleVerDes.LeoEcsLiteZoo;
using Runtime.Base;
using UnityEngine;
using VContainer;

namespace Runtime.Debug
{
    [CreateAssetMenu(fileName = "DebugFeature", menuName = "Game/Features/DebugFeature")]
    public class DebugFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DebugFeature>(Lifetime.Transient);
        }

        public override IEcsFeature Get(IObjectResolver objectResolver)
        {
            return objectResolver.Resolve<DebugFeature>();
        }
    }
}