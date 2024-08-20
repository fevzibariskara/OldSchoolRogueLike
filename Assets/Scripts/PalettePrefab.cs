using Assets.Scripts.World.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PalettePrefab : MonoBehaviour
    {
        [SerializeField] private TileType tileType;

        public TileType GetTileType()
        {
            return tileType;
        }
    }
}