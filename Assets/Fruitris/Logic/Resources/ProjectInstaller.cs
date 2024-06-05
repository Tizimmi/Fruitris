using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField]
    private GameStateHandler _gameStateHandler;
    public override void InstallBindings()
    {
        Container.Bind<GamePrefabFactory>().FromNew().AsSingle().NonLazy();
        //Container.Bind<LeaderBoard>().FromNew().AsSingle().NonLazy();
        //Container.Bind<GameStateHandler>().FromInstance(_gameStateHandler).AsSingle().NonLazy();
    }
}
