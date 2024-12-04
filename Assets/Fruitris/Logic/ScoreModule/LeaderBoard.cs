using Fruitris.Logic.GameModule.GameManagmentLogic;
using Fruitris.Logic.PlayerModule;
using System.Collections.Generic;
using UnityEngine;

namespace Fruitris.Logic.ScoreModule
{
	public static class LeaderBoard
	{
		public static readonly List<PlayerData> AllPlayers;
		private static readonly List<PlayerData> TopPlayers = new();

		static LeaderBoard()
		{
			AllPlayers = LeaderboardSaveHandler.Load()._allPlayerData;
		}

		public static void AddPlayerToAllPlayers(PlayerData data)
		{
			AllPlayers.Add(data);
			SaveLeaderBoard();
		}

		public static void SaveLeaderBoard()
		{
			LeaderboardSaveHandler.Save(new LeaderboardSaveHandler.SaveData(AllPlayers));
		}

		public static List<PlayerData> GetTopPlayers(ref int count)
		{
			if (count > AllPlayers.Count)
				count = AllPlayers.Count;

			AllPlayers.Sort();
			TopPlayers.Clear();

			for (var i = 0; i < count; i++)
				TopPlayers.Add(AllPlayers[i]);

			return TopPlayers;
		}

		public static void ShowLeaderboard()
		{
			foreach (var item in AllPlayers)
				Debug.Log(item._nickname + " " + item._maxScore);
		}
	}
}