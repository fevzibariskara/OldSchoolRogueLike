using Assets.Scripts.World.Generator;
using UnityEngine;

namespace Assets.Scripts.World.Map
{
    public class TrainingDataStore : MonoBehaviour
    {
        [SerializeField] private TrainingType largeBuilding;

        public TrainingType GetLargeBuilding()
        {
            return largeBuilding;
        }
    }
}