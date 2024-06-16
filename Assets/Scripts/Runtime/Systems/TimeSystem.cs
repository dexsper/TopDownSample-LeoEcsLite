using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using UnityEngine;

namespace Systems
{
    public sealed class TimeSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<TimeService> _timeService = default;
        
        public void Run(IEcsSystems systems)
        {
            _timeService.Value.Time = Time.time;
            _timeService.Value.UnscaledTime = Time.unscaledTime;
            _timeService.Value.DeltaTime = Time.deltaTime;
            _timeService.Value.UnscaledDeltaTime = Time.unscaledDeltaTime;
        }
    }
}