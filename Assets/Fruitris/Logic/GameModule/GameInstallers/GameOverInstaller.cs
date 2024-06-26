using UnityEngine;
using Zenject;

public class GameOverInstaller : MonoInstaller
{
    [SerializeField]
    private LeaderBoardView _leaderboard;
    public override void InstallBindings()
    {
        Container.Bind<GamePrefabFactory>().AsSingle().NonLazy();
        Container.Bind<LeaderBoardView>().FromInstance(_leaderboard).AsSingle().NonLazy();
    }
}

