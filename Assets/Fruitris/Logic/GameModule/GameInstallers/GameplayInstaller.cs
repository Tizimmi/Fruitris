using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private ScoreView _scoreView;

    public override void InstallBindings()
    {
        Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle().NonLazy();
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
        Container.Bind<GamePrefabFactory>().FromNew().AsSingle().NonLazy();
        Container.Bind<MergeFruitsStrategy>().FromNew().AsSingle().NonLazy();
        Container.Bind<Player>().FromResolveGetter<GamePrefabFactory>(f => f.InstantiatePrefab<Player>(_playerPrefab,Vector3.zero,Quaternion.identity, _spawner.transform)).AsSingle().NonLazy();
    }

}
