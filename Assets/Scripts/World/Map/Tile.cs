using Assets.Scripts.World.Entities;
using UnityEngine;

namespace Assets.Scripts.World.Map
{
    public class Tile
    {
        private Vector2 _coord;
        private Sprite _texture;
        private GameObject _spriteInstance;
        private TileType _tileType;
        private Entity _presentEntity;
        public Tile()
        {
        }

        public Tile(TileType tileType, Vector2 coord)
        {
            _tileType = tileType;
            _coord = coord;
            _texture = tileType.GetTexture();
        }

        public bool IsTransparent()
        {
            return _tileType.transparent;
        }

        public bool IsWalkable()
        {
            return _tileType.walkable;
        }

        public Vector2 GetCoord()
        {
            return _coord;
        }

        public Sprite GetTexture()
        {
            return _texture;
        }

        public void SetSpriteInstance(GameObject instance)
        {
            _spriteInstance = instance;
        }

        public void AddEntity(Entity entity)
        {
            _presentEntity = entity;
        }

        public void RemoveEntity()
        {
            _presentEntity = null;
        }

        public Entity GetEntity()
        {
            return _presentEntity;
        }
    }
}