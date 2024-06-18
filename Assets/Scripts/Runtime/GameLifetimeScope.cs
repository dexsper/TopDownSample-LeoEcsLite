using System;
using System.Collections.Generic;
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<FeatureInstaller> _features;
        [SerializeField] private bool _worldDebug;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var feature in _features) 
                feature.Install(builder);

            builder.Register<EntryPointDispatcher>(Lifetime.Scoped);
            builder.RegisterEntryPoint<GameEcsRunner>().WithParameter(_worldDebug).As<EcsRunner>();
            
            builder.RegisterBuildCallback(AddFeaturesToRunner);
        }

        private void AddFeaturesToRunner<T>(T resolver) where T : IObjectResolver
        {
            if (!resolver.TryResolve(out EcsRunner ecsRunner))
                throw new Exception("GameEcsRunner is not injected");

            ecsRunner.SetWorld(new EcsWorld());

            foreach (var feature in _features) ecsRunner.AddFeature(feature.Get(resolver));

            resolver.Resolve<EntryPointDispatcher>().Dispatch();
        }
    }
}