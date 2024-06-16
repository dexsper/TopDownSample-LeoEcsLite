using AB_Utility.FromSceneToEntityConverter;
using Leopotam.EcsLite;
using UnityEngine;

namespace Components.Converters
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyComponentConverter : BaseConverter
    {
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            if (!entityWithWorld.Unpack(out var world, out var entity)) 
                return;
            
            ref var component = ref world.GetPool<RigidbodyComponent>().Add(entity);
            
            component = new RigidbodyComponent
            {
                Value = GetComponent<Rigidbody>()
            };
        }
    }
}