using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public class ModelsBuilder : IInitializable
    {
        private const string PATH = "Assets/Input";

        private List<GameObject> preFabList = new List<GameObject>();
        private FileInfo[] fileInfo;
        public List<GameObject> PreFabList => preFabList;

        public void Initialize()
        {
            BuildModels();
        }

        private void BuildModels()
        {
            fileInfo = new DirectoryInfo(PATH).GetFiles();

            foreach (var file in fileInfo)
            {
                Object catchedModel = AssetDatabase.LoadAssetAtPath(PATH + "/" + file.Name, typeof(GameObject));

                if (catchedModel != null)
                {
                    GameObject newModel = GameObject.Instantiate(catchedModel) as GameObject;
                    newModel.transform.rotation = Quaternion.identity;
                    preFabList.Add(newModel);
                }
            }
        }
    }
}