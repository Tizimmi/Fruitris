using Fruitris.Logic.PlayerModule;
using Fruitris.Logic.ScoreModule;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

namespace Fruitris.Logic.GameModule.GameManagmentLogic
{
	public static class GameStateHandler
	{
		public static PlayerData _currentPlayer;

		public static void CreatePlayer(PlayerData data)
		{
			PlayerSaveHandler.SavePlayerInfo(data);
			_currentPlayer = data;
		}

		public static void GameStart()
		{
			if (_currentPlayer == null)
				CreatePlayer(new PlayerData("Noname", 0));

			SceneManager.LoadScene("GameplayScene");
		}

		public static void GameOver()
		{
			if (LeaderBoard.AllPlayers.Contains(_currentPlayer) == false)
				LeaderBoard.AddPlayerToAllPlayers(_currentPlayer);

			SceneManager.LoadScene(2);
			LeaderBoard.ShowLeaderboard();
		}

		public static void GameRestart() { }

		public static void GameQuit()
		{
			SaveGameData();
			Application.Quit();
		}

		private static void SaveGameData()
		{
			_currentPlayer?.SavePlayerData();
			LeaderBoard.SaveLeaderBoard();
		}

		public static void ClearPlayer()
		{
			_currentPlayer = null;
		}
	}
}