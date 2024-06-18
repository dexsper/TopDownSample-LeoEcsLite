using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Runtime.Base;
using Runtime.Input.Components;
using Runtime.Input.Systems;
using VContainer;

namespace Runtime.Input
{
    public class InputFeature : BaseFeature, IEcsUpdateFeature
    {
        public InputFeature(IObjectResolver objectResolver, bool debug) : base(objectResolver, debug)
        {
        }
        
        public override void SetupUpdateSystems(IEcsSystems systems)
        {
            base.SetupUpdateSystems(systems);
            
            systems.Add(new DelHereSystem<RotateCommand>());
            systems.Add(new DelHereSystem<MoveCommand>());

            systems.Add(_objectResolver.Resolve<InputSystem>());
            systems.Add(_objectResolver.Resolve<PlayerInputSystem>());
        }
    }
}