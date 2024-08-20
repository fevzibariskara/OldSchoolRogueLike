using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class TypeObject : ScriptableObject
    {
        [SerializeField] private Sprite[] textures;
        public bool transparent;
        public bool walkable;

        public Sprite GetTexture()
        {

            if (textures == null || !textures.Any())
            {
                Debug.LogError($"No texture defined for {name}");
                return null;
            }

            return textures[Random.Range(0, textures.Length)];
        }
    }
}