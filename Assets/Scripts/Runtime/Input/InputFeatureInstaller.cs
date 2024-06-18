using Runtime.Base;
using Runtime.Input.Services;
using Runtime.Input.Systems;
using UnityEngine;
using VContainer;

namespace Runtime.Input
{
    [CreateAssetMenu(fileName = "InputFeature", menuName = "Game/Features/InputFeature")]
    public class InputFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<InputService>(Lifetime.Singleton);

            builder.Register<InputSystem>(Lifetime.Transient);
            builder.Register<PlayerInputSystem>(Lifetime.Transient);
            builder.Register<InputFeature>(Lifetime.Transient).WithParameter(_isDebug);
        }

        public override BaseFeature Get(IObjectResolver objectResolver)
        {
            return objectResolver.Resolve<InputFeature>();
        }
    }
}