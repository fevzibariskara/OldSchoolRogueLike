using UnityEngine;

namespace Assets.Scripts.World.Entities
{
    public class EntityStore : MonoBehaviour
    {
        [SerializeField] private EntityType human;

        [SerializeField] private GameObject playerPrefab;

        public Entity GetHuman()
        {
            return human.NewEntity();
        }

        public GameObject GetPlayerPrefab()
        {
            return playerPrefab;
        }
    }
}