using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.World.Generator
{
    public class MapTrainer : MonoBehaviour
    {
        [SerializeField] private Training training;
        [SerializeField] private string templateName;

        [Serializable]
        public struct TrainingTemplate
        {
            public byte[,] Sample;
            public string[] TileNames;
        }

        private void SaveTrainingTemplate(string tName, byte[,] sample, Object[] tiles)
        {
            if (sample == null)
            {
                print("Samples null aborting..");
                return;
            }

            if (tiles == null)
            {
                print("Tiles null aborting..");
                return;
            }

            var template = new TrainingTemplate
            {
                Sample = sample,
                TileNames = new string[tiles.Length]
            };

            for (int i = 0; i < tiles.Length; i++)
            {
                var tile = tiles[i];

                if (tile == null)
                {
                    continue;
                }

                template.TileNames[i] = tile.name;
                                
            }

            SaveTrainingTemplateFile(tName, template);
        }

        private void SaveTrainingTemplateFile(string saveFile, object state)
        {
            var path = GetPathFromSaveFile(saveFile);

            print("Saving to" + path);

            using var stream = File.Open(path, FileMode.Create);

            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, state);

            print("Template saved successfully!");
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return $@"{Application.dataPath}\Scripts\World\Generator\Training Data\Template Files\{saveFile}.bytes";
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(MapTrainer))]
        public class MapTrainingEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                MapTrainer trainer = (MapTrainer)target;
                if (trainer.training != null)
                {
                    if (GUILayout.Button("Save Template"))
                    {
                        trainer.SaveTrainingTemplate(trainer.templateName,
                                                     trainer.training.sample,
                                                     trainer.training.tiles);
                    }
                }

                DrawDefaultInspector();
            }
        }
#endif
    }
}