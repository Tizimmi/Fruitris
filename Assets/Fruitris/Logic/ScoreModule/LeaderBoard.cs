using System.Collections.Generic;
using UnityEngine;

public static class LeaderBoard
{
	public static List<PlayerData> _allPlayers = new();
	private static readonly List<PlayerData> _topPlayers = new();

	static LeaderBoard()
	{
		_allPlayers = LeaderboardSaveHandler.Load()._allPlayerData;
	}

	public static void AddPlayerToAllPlayers(PlayerData data)
	{
		_allPlayers.Add(data);
		SaveLeaderBoard();
	}

	public static void SaveLeaderBoard()
	{
		LeaderboardSaveHandler.Save(new(_allPlayers));
	}

	public static List<PlayerData> GetTopPlayers(ref int count)
	{
		if (count > _allPlayers.Count) // костылечек
			count = _allPlayers.Count;

		_allPlayers.Sort();
		_topPlayers.Clear();

		for (var i = 0; i < count; i++)
			_topPlayers.Add(_allPlayers[i]);

		return _topPlayers;
	}

	public static void ShowLeaderboard()
	{
		foreach (var item in _allPlayers)
			Debug.Log(item.Nickname + " " + item.MaxScore);
	}
}