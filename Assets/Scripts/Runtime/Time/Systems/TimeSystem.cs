using Leopotam.EcsLite;
using Runtime.Time.Services;

namespace Runtime.Time.Systems
{
    public sealed class TimeSystem : IEcsRunSystem
    {
        private readonly TimeService _timeService;

        public TimeSystem(TimeService timeService)
        {
            _timeService = timeService;
        }
        
        public void Run(IEcsSystems systems)
        {
            _timeService.Time = UnityEngine.Time.time;
            _timeService.UnscaledTime = UnityEngine.Time.unscaledTime;
            _timeService.DeltaTime = UnityEngine.Time.deltaTime;
            _timeService.UnscaledDeltaTime = UnityEngine.Time.unscaledDeltaTime;
        }
    }
}