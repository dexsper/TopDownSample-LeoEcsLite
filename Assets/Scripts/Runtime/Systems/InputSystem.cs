using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using UnityEngine;

namespace Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<InputService> _inputService = default;
        
        public void Run(IEcsSystems systems)
        {
            _inputService.Value.Horizontal = Input.GetAxisRaw ("Horizontal");
        }
    }
}