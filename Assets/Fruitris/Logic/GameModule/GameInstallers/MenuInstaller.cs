using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField]
    private GameStateHandler _gameStateHandler;
    public override void InstallBindings()
    {
        Container.Bind<GameStateHandler>().FromInstance(_gameStateHandler).AsSingle().NonLazy();
    }
}