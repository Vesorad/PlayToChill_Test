using Assets.Scripts.Models;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ButtonsController
    {
        private ModelsManager modelsManager;
        private GameObject canvas;

        public ButtonsController(ModelsManager modelsManager, GameObject canvas)
        {
            this.modelsManager = modelsManager;
            this.canvas = canvas;
        }

        public IEnumerator CaptureScreen()
        {
            yield return null;

            canvas.SetActive(false);
            yield return new WaitForEndOfFrame();

            ScreenCapture.CaptureScreenshot(Application.dataPath + "/Photos/" +
                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
            canvas.SetActive(true);
            UnityEditor.AssetDatabase.Refresh();
        }

        public void GoToNextObject()
        {
            modelsManager.BackModelToStartRotation();
            modelsManager.ChangeCurrentModel(1);
            modelsManager.ActiveObject();
        }

        public void GoToPreviousObject()
        {
            modelsManager.BackModelToStartRotation();
            modelsManager.ChangeCurrentModel(-1);
            modelsManager.ActiveObject();
        }
    }
}
