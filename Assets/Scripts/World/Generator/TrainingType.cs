using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.World.Generator
{
    [CreateAssetMenu(menuName = "My Assets/Training Type")]
    public class TrainingType : ScriptableObject
    {
        [SerializeField] private TextAsset[] templates;

        public MapTrainer.TrainingTemplate GetTemplate()
        {
            if (templates == null || templates.Length < 1)
            {
                return new MapTrainer.TrainingTemplate();
            }

            var template = templates[Random.Range(0, templates.Length)];

            var stream = new MemoryStream(template.bytes);

            var formatter = new BinaryFormatter();

            var contents = formatter.Deserialize(stream);

            return (MapTrainer.TrainingTemplate)contents;
        }
    }
}