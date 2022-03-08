using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class UiPhotoFacade : MonoBehaviour
    {
        private ButtonsController buttonsController;

        [Inject]
        public void Construct(ButtonsController buttonsController)
        {
            this.buttonsController = buttonsController;
        }

        public void ButtonBack()
        {
            buttonsController.GoToPreviousObject();
        }

        public void ButtonForward()
        {
            buttonsController.GoToNextObject();
        }

        public void ButtonPhoto()
        {
            StartCoroutine(buttonsController.CaptureScreen());
        }
    }
}
