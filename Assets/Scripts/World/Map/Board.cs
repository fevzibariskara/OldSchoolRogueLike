using Assets.Scripts.World.Entities;
using UnityEngine;

namespace Assets.Scripts.World.Map
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private GameObject terrainSlotPrefab;

        public void Draw(Map map)
        {
            for (int x = 0; x < map.GetWidth(); x++)
            {
                for (int y = 0; y < map.GetHeight(); y++)
                {
                    var coord = new Vector2(x, y);

                    var tile = map.GetTileAt(coord);

                    var tileInstance = Instantiate(terrainSlotPrefab, coord, Quaternion.identity, transform);

                    tileInstance.GetComponent<SpriteRenderer>().sprite = tile.GetTexture();

                    tileInstance.name = $"{x},{y}";

                    tile.SetSpriteInstance(tileInstance);
                }
            }

            PlacePlayer(map);
        }

        private void PlacePlayer(Map map)
        {
            var startingPoint = new Vector2(40, 12);

            var entityStore = FindObjectOfType<EntityStore>();

            var player = entityStore.GetHuman();

            var playerInstance = Instantiate(entityStore.GetPlayerPrefab(), startingPoint, Quaternion.identity, transform);

            playerInstance.GetComponent<SpriteRenderer>().sprite = player.GetTexture();

            player.SetSpriteInstance(playerInstance);

            var playerMovement = playerInstance.GetComponent<PlayerMovement>();

            playerMovement.SetPlayer(player);

            player.SetMap(map);

            var startingTile = map.GetTileAt(startingPoint);

            startingTile.AddEntity(player);
        }
    }
}