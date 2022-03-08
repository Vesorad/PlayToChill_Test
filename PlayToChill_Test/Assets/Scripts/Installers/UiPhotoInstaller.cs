using Assets.Scripts.Models;
using Assets.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class UiPhotoInstaller : MonoInstaller
    {
        [SerializeField] private GameObject canvas;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ModelsManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<ModelRotateAndZoom>().AsSingle();
            Container.BindInterfacesAndSelfTo<ButtonsController>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameObject>().FromInstance(canvas).AsSingle();
        }
    }
}