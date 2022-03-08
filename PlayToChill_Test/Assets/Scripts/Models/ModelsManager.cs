using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public class ModelsManager : IInitializable
    {
        private List<GameObject> preFabList;
        private int currentPrefab;
        private Quaternion currentPrefabRotation;

        public Transform CurrentTransformPreFab => preFabList[currentPrefab].transform;

        public ModelsManager(ModelsBuilder modelsBuilder)
        {
            preFabList = modelsBuilder.PreFabList;
        }

        public void Initialize()
        {
            ActiveObject();
        }

        public void ActiveObject()
        {
            CheckArray();

            foreach (var model in preFabList)
            {
                model.SetActive(false);
            }

            currentPrefabRotation = preFabList[currentPrefab].transform.rotation;
            preFabList[currentPrefab].SetActive(true);
        }

        private void CheckArray()
        {
            if (currentPrefab < 0)
            {
                currentPrefab = preFabList.Count - 1;
            }
            else if (currentPrefab >= preFabList.Count)
            {
                currentPrefab = 0;
            }
        }

        public void BackModelToStartRotation()
        {
            preFabList[currentPrefab].transform.rotation = currentPrefabRotation;
        }

        public void ChangeCurrentModel(int value)
        {
            currentPrefab += value;
        }
    }
}