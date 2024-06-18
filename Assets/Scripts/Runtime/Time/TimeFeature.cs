using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base;
using Runtime.Time.Systems;
using VContainer;

namespace Runtime.Time
{
    public class TimeFeature : BaseFeature, IEcsUpdateFeature
    {
        public TimeFeature(IObjectResolver objectResolver, bool debug) : base(objectResolver, debug)
        {
        }

        public override void SetupUpdateSystems(IEcsSystems systems)
        {
            base.SetupUpdateSystems(systems);
            
            systems.Add(_objectResolver.Resolve<TimeSystem>());
        }
    }
}