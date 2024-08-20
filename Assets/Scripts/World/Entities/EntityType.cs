using UnityEngine;

namespace Assets.Scripts.World.Entities
{
    [CreateAssetMenu(menuName = "My Assets/Entity Type")]
    public class EntityType : TypeObject
    {
        public Entity NewEntity()
        {
            return new Entity(this);
        }
    }
}