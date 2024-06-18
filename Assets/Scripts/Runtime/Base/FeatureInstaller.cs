using AleVerDes.LeoEcsLiteZoo;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime.Base
{
    public abstract class FeatureInstaller: ScriptableObject, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);

        public abstract IEcsFeature Get(IObjectResolver objectResolver);
    }
}