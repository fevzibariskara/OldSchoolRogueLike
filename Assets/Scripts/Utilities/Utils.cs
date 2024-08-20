using Assets.Scripts.World.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Utils
    {
        public static int GetIndexFromCoord(Vector2 coord, Map map)
        {
            return (int)(coord.y * map.GetWidth() + coord.x);
        }
    }
}