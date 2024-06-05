using Zenject;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GamePrefabFactory>().AsSingle().NonLazy();
    }
}
