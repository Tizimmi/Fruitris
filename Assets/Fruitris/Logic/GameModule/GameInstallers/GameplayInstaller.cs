using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private ScoreView _scoreView;
    [SerializeField]
    private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromResolveGetter<GamePrefabFactory>(factory => factory.InstantiatePrefab<Player>(_playerPrefab, Vector3.zero, Quaternion.identity, gameObject.transform)).AsSingle().NonLazy();
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
        Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle().NonLazy();
        Container.Bind<LeaderBoard>().FromNew().AsSingle();
        Container.Bind<MergeFruitsStrategy>().FromNew().AsSingle().NonLazy();
    }    
}
