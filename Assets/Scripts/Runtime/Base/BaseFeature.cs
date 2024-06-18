using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;
using VContainer;

namespace Runtime.Base
{
    public abstract class BaseFeature : IEcsFeature
    {
        protected readonly IObjectResolver _objectResolver;
        protected readonly bool _isDebug;

        public BaseFeature(IObjectResolver objectResolver, bool debug)
        {
            _objectResolver = objectResolver;
            _isDebug = debug;
        }

        protected virtual void SetupDebugSystems(IEcsSystems systems, string systemsType = default)
        {
#if UNITY_EDITOR
            if(!_isDebug)
                return;
            
            systems
                .Add(new EcsSystemsDebugSystem($"{GetType().Name} {systemsType}"));
#endif
        }

        public virtual void SetupUpdateSystems(IEcsSystems systems)
        {
            SetupDebugSystems(systems, "Update");
        }

        public virtual void SetupFixedUpdateSystems(IEcsSystems systems)
        {
            SetupDebugSystems(systems, "Fixed");
        }

        public virtual void SetupLateUpdateSystems(IEcsSystems systems)
        {
            SetupDebugSystems(systems, "Late");
        }
    }
}