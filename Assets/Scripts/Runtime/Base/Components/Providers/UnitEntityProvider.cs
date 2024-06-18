using AleVerDes.LeoEcsLiteZoo;
using UnityEngine;

namespace Runtime.Base.Components.Providers
{
    [DisallowMultipleComponent]
    public class UnitEntityProvider : UnityObjectProvider
    {
        protected override void Setup()
        {
            base.Setup();

            Add<UnitComponent>();
        }
    }
}