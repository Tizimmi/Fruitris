using Fruitris.Logic.Fruits.Logic;
using Fruitris.Logic.ScoreModule;
using UnityEngine;
using Zenject;

namespace Fruitris.Logic.GameModule.GameInstallers
{
	public class GameplayInstaller : MonoInstaller
	{
		[SerializeField]
		private Spawner _spawner;
		[SerializeField]
		private ScoreView _scoreView;
		[SerializeField]
		private LeaderBoardView _leaderboard;

		private void OnApplicationQuit() { }

		public override void InstallBindings()
		{
			Container.Bind<GamePrefabFactory>().AsSingle().NonLazy();
			Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
			Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle().NonLazy();
			Container.Bind<MergeFruitsStrategy>().FromNew().AsSingle().NonLazy();
			Container.Bind<LeaderBoardView>().FromInstance(_leaderboard).AsSingle().NonLazy();
		}
	}
}