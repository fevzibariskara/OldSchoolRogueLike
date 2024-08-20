using Assets.Scripts.World.Map;
using UnityEngine;

namespace Assets.Scripts.World.Entities
{
    public class Entity
    {
        private GameObject _spriteInstance;
        private Sprite _texture;
        private EntityType _entityType;

        private Map.Map _currentMap;

        public Entity(EntityType entityType)
        {
            _entityType = entityType;

            _texture = entityType.GetTexture();
        }

        public void SetMap(Map.Map map)
        {
            _currentMap = map;
        }

        public void SetSpriteInstance(GameObject instance)
        {
            _spriteInstance = instance;
        }

        public Sprite GetTexture()
        {
            return _texture;
        }

        public void Move(Direction direction)
        {
            var vDirection = new Vector3(direction.DeltaX, direction.DeltaY);

            var position = _spriteInstance.transform.position;

            var targetCoord = position + vDirection;

            var targetTile = _currentMap.GetTileAt(targetCoord);

            if (targetTile.IsWalkable())
            {
                Debug.Log("Player blocked!");
                return;
            }

            var currentTile = _currentMap.GetTileAt(position);

            currentTile.RemoveEntity();

            targetTile.AddEntity(this);

            position += vDirection;

            _spriteInstance.transform.position = position;
        }
    }
}