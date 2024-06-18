using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime.Base
{
    public abstract class FeatureInstaller : ScriptableObject, IInstaller
    {
        [SerializeField] protected bool _isDebug;
        
        public abstract void Install(IContainerBuilder builder);

        public abstract BaseFeature Get(IObjectResolver objectResolver);
    }
}