using AleVerDes.LeoEcsLiteZoo;
using UnityEngine;

namespace Runtime.Base.Components.Providers
{
    [DisallowMultipleComponent]
    public class PlayerEntityProvider : EcsEntityProvider
    {
        protected override void Setup()
        {
            Add<PlayerComponent>();
            Add<UnitLeaderComponent>();
        }
    }
}