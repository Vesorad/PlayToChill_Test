using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public class ModelRotateAndZoom : IInitializable, ITickable
    {
        private const string SCROLL_WHEEL = "Mouse ScrollWheel";

        private Transform currentTransform;
        private Vector3 mPrevPos = Vector3.zero;
        private Vector3 mPosDelta = Vector3.zero;
        private Transform cameraTransform;
        private float fieldOfView;

        private ModelsManager modelsManager;
        private Settings settings;

        public ModelRotateAndZoom(ModelsManager modelsManager, Settings settings)
        {
            this.modelsManager = modelsManager;
            this.settings = settings;
        }

        public void Initialize()
        {
            cameraTransform = Camera.main.transform;
            fieldOfView = Camera.main.fieldOfView;
        }

        public void Tick()
        {
            ZoomOnScrool();
            ClickAndRotate();
        }

        private void ZoomOnScrool()
        {
            fieldOfView -= Input.GetAxis(SCROLL_WHEEL) * settings.Sensitivity;
            fieldOfView = Mathf.Clamp(fieldOfView, settings.MinZoom, settings.MaxZoom);

            Camera.main.fieldOfView = fieldOfView;
        }

        private void ClickAndRotate()
        {
            if (Input.GetMouseButton(0))
            {
                currentTransform = modelsManager.CurrentTransformPreFab;
                mPosDelta = Input.mousePosition - mPrevPos;

                if (Vector3.Dot(currentTransform.up, Vector3.up) >= 0)
                {
                    currentTransform.Rotate(cameraTransform.up, -Vector3.Dot(mPosDelta,
                        cameraTransform.right), Space.World);
                }
                else
                {
                    currentTransform.Rotate(Camera.main.transform.up, Vector3.Dot(mPosDelta,
                        Camera.main.transform.right), Space.World);
                }

                currentTransform.Rotate(cameraTransform.right, Vector3.Dot(mPosDelta,
                    cameraTransform.up), Space.World);
            }

            mPrevPos = Input.mousePosition;
        }

        [Serializable]
        public class Settings
        {
            public float MinZoom;
            public float MaxZoom;
            public float Sensitivity;
        }
    }
}