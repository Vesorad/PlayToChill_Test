using Assets.Scripts.Models;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ModelsBuilder>().AsSingle();
        }
    }
}