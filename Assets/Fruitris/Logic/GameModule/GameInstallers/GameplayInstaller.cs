using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private ScoreView _scoreView;

    public override void InstallBindings()
    {
        Container.Bind<LeaderBoard>().FromNew().AsSingle();
        Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle().NonLazy();
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
        Container.Bind<MergeFruitsStrategy>().FromNew().AsSingle().NonLazy();
    }

}
