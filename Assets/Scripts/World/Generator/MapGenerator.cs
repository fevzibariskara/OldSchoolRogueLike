using Assets.Scripts.World.Map;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.World.Generator
{
    public class MapGenerator
    {
        private TrainingDataStore _trainingDataStore;
        private TerrainStore _terrainStore;
        private Training _training;
        private OverlapWFC _overlap;

        public MapGenerator()
        {
            _trainingDataStore = Object.FindObjectOfType<TrainingDataStore>();
            _terrainStore = Object.FindObjectOfType<TerrainStore>();
            _training = Object.FindObjectOfType<Training>();
            _overlap = Object.FindObjectOfType<OverlapWFC>();
        }

        public void GenerateLocalMap(Map.Map localMap)
        {
            GenerateBuildings(localMap);

            for (int x = 0; x < localMap.GetWidth(); x++)
            {
                for (int y = 0; y < localMap.GetHeight(); y++)
                {
                    var coord = new Vector2(x, y);

                    var tile = localMap.GetTileAt(coord);

                    if (tile == null)
                    {
                        tile = _terrainStore.GroundTile(coord);

                        localMap.SetTileAt(coord, tile);
                    }
                }
            }
        }

        private void GenerateBuildings(Map.Map localMap)
        {
            var tType = _trainingDataStore.GetLargeBuilding();

            GenerateTemplate(tType);

            for (int i = 0; i < _overlap.group.childCount; i++)
            {
                var palettePrefab = _overlap.group.GetChild(i).GetComponent<PalettePrefab>();

                var tile = palettePrefab.GetTileType().NewTile(palettePrefab.transform.localPosition);

                localMap.SetTileAt(palettePrefab.transform.localPosition, tile);
            }
        }

        private void GenerateTemplate(TrainingType tType)
        {
            MapTrainer.TrainingTemplate template = tType.GetTemplate();

            _training.sample = template.Sample;

            _training.tiles = new Object[template.TileNames.Length];

            _training.RS = new int[template.TileNames.Length];

            for (int i = 0; i < template.TileNames.Length; i++)
            {
                var tileName = template.TileNames[i];

                if (string.IsNullOrEmpty(tileName))
                {
                    continue;
                }

                var prefab = (GameObject)Resources.Load(tileName);

                _training.tiles[i] = prefab;
            }

            _overlap.Generate();
            _overlap.Run();
        }        
    }
}