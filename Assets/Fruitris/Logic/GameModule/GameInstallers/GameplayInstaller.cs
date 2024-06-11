using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private ScoreView _scoreView;
    [SerializeField]
    private LeaderBoardView _leaderboard;

    public override void InstallBindings()
    {
        Container.Bind<GamePrefabFactory>().AsSingle().NonLazy();
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
        Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle().NonLazy();
        Container.Bind<MergeFruitsStrategy>().FromNew().AsSingle().NonLazy();
        Container.Bind<LeaderBoardView>().FromInstance(_leaderboard).AsSingle().NonLazy();
    }

    private void OnApplicationQuit()
    {
        GameStateHandler._currentPlayer?.SavePlayerData();
        LeaderBoard.SaveLeaderBoard();
    }
}
