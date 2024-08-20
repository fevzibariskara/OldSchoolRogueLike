using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.World.Map
{
    public class TerrainStore : MonoBehaviour
    {
        [SerializeField] private TileType dirt;
        [SerializeField] private TileType tree;
        [SerializeField] private TileType ground;

        public Tile DirtTile(Vector2 coord)
        {
            return dirt.NewTile(coord);
        }

        public Tile TreeTile(Vector2 coord)
        {
            return tree.NewTile(coord);
        }

        public Tile GroundTile(Vector2 coord)
        {
            return ground.NewTile(coord);
        }
    }
}