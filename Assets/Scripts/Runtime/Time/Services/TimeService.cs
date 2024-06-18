namespace Runtime.Time.Services
{
    public sealed class TimeService
    {
        public float DeltaTime { get; internal set; }
        public float Time { get; internal set; }
        public float UnscaledDeltaTime { get; internal set; }
        public float UnscaledTime { get; internal set; }
    }
}