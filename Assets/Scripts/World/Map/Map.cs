using Assets.Scripts.Utilities;
using Assets.Scripts.World.Generator;
using UnityEngine;

namespace Assets.Scripts.World.Map
{
    public class Map
    {
        private const int Width = 80;
        private const int Height = 25;

        private Tile[] _terrain;

        public Map()
        {
            var terrainStore = Object.FindObjectOfType<TerrainStore>();

            _terrain = new Tile[Width * Height];

            var generator = new MapGenerator();

            generator.GenerateLocalMap(this);
        }

        public Tile GetTileAt(Vector2 coord)
        {
            var index = Utils.GetIndexFromCoord(coord, this);

            return _terrain[index];
        }

        public void SetTileAt(Vector2 coord, Tile tile)
        {
            var index = Utils.GetIndexFromCoord(coord, this);

            _terrain[index] = tile;
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }
    }
}