using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;

#if UNITY_EDITOR
using Leopotam.EcsLite.UnityEditor;
#endif

namespace Runtime.Debug
{
    public class DebugFeature : IEcsUpdateFeature
    {
        public void SetupUpdateSystems(IEcsSystems systems)
        {
#if UNITY_EDITOR
            systems
                .Add(new EcsWorldDebugSystem())
                .Add(new EcsSystemsDebugSystem());
#endif
        }
    }
}