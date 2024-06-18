using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Time.Systems;
using VContainer;

namespace Runtime.Time
{
    public class TimeFeature : IEcsUpdateFeature
    {
        private readonly IObjectResolver _objectResolver;

        public TimeFeature(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void SetupUpdateSystems(IEcsSystems systems)
        {
            _objectResolver.Resolve<TimeSystem>();
        }
    }
}