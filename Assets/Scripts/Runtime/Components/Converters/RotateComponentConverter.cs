using AB_Utility.FromSceneToEntityConverter;
using Leopotam.EcsLite;
using UnityEngine;

namespace Components.Converters
{
    [DisallowMultipleComponent]
    public class RotateComponentConverter : BaseConverter
    {
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            if (!entityWithWorld.Unpack(out var world, out var entity)) 
                return;
            
            ref var component = ref world.GetPool<RotateComponent>().Add(entity);
            
            component = new RotateComponent
            {
                Value = transform.eulerAngles
            };
        }
    }
}