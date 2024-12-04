using Fruitris.Logic.ScoreModule;
using UnityEngine;
using Zenject;

namespace Fruitris.Logic.GameModule.GameInstallers
{
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
}