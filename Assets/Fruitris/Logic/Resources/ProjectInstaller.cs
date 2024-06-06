using Zenject;
using UnityEngine;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GamePrefabFactory>().FromNew().AsSingle().NonLazy();
    }
}
