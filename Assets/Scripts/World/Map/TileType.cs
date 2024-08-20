using UnityEngine;

namespace Assets.Scripts.World.Map
{
    [CreateAssetMenu(menuName = "My Assets/Tile Type")]
    public class TileType : TypeObject
    {        
        public Tile NewTile(Vector2 coord)
        {
            return new Tile(this, coord);
        }        
    }
}