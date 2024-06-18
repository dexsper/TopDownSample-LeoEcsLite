using System;
using AleVerDes.LeoEcsLiteZoo;
using VContainer.Unity;

namespace Runtime
{
    public class GameEcsRunner : EcsRunner, IInitializable, ITickable, ILateTickable, IFixedTickable, IDisposable
    {
        public void Initialize()
        {
            Init();
        }
        
        public void Tick()
        {
            Update();
        }

        public void LateTick()
        {
            LateUpdate();
        }

        public void FixedTick()
        {
            FixedUpdate();
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}