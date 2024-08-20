using Assets.Scripts.World.Map;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            var map = new Map();

            var board = FindObjectOfType<Board>();

            board.Draw(map);
        }
    }
}