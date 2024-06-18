using Leopotam.EcsLite;
using Runtime.Input.Services;

namespace Runtime.Input.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly InputService _inputService;

        public InputSystem(InputService inputService)
        {
            _inputService = inputService;
        }

        public void Run(IEcsSystems systems)
        {
            _inputService.Horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
        }
    }
}