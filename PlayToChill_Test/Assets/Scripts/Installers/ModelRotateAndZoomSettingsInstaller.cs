using Assets.Scripts.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    [CreateAssetMenu(menuName = "Installers/RotateModelSettingsInstaller")]
    public class ModelRotateAndZoomSettingsInstaller : ScriptableObjectInstaller<ModelRotateAndZoomSettingsInstaller>
    {
        [SerializeField] private ModelRotateAndZoom.Settings rotateModelSettings;

        public override void InstallBindings()
        {
            Container.Bind<ModelRotateAndZoom.Settings>().FromInstance(rotateModelSettings);
        }
    }
}