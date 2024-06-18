using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base.Components;
using Runtime.Input.Systems;
using VContainer;

namespace Runtime.Input
{
    public class InputFeature : IEcsUpdateFeature
    {
        private readonly IObjectResolver _objectResolver;

        public InputFeature(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void SetupUpdateSystems(IEcsSystems systems)
        {
            systems.Add(new DelHereSystem<RotateCommand>());
            systems.Add(new DelHereSystem<MoveCommand>());
            
            systems.Add(_objectResolver.Resolve<InputSystem>());
            systems.Add(_objectResolver.Resolve<PlayerInputSystem>());
        }
    }
}