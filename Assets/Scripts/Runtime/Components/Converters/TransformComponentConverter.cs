using AB_Utility.FromSceneToEntityConverter;
using Leopotam.EcsLite;

namespace Components.Converters
{
    public class TransformComponentConverter : BaseConverter
    {
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            if (!entityWithWorld.Unpack(out var world, out var entity)) 
                return;
            
            ref var component = ref world.GetPool<TransformComponent>().Add(entity);
            
            component = new TransformComponent
            {
                Value = transform
            };
        }
    }
}