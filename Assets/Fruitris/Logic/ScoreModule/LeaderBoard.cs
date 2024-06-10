using UnityEngine;
using System.Collections.Generic;

public static class LeaderBoard
{
    public static List<PlayerData> _allPlayers = new();
    private static List<PlayerData> _topPlayers = new();

    static LeaderBoard()
    {
        _allPlayers = LeaderboardSaveHandler.Load().PlayerData;
        if (_allPlayers.Count > 0)
        {
            foreach (var item in _allPlayers)
            {
                Debug.Log(item.Nickname);
            }
        }
        else
        {
            Debug.Log("ПУСТОЙ");
        }
    }

    public static void AddPlayerToAllPlayers(PlayerData data)
    {
        _allPlayers.Add(data);
    }

    public static List<PlayerData> GetTopPlayers(ref int count)
    {
        if (count > _allPlayers.Count) // костылечек
        {
            count = _allPlayers.Count;
        }

        if (count < 1)
        {
            return new List<PlayerData> { new PlayerData("Jora", 123) };
        }
        _allPlayers.Sort();

        for (int i = 0; i < count; i++)
        {
            _topPlayers.Add(_allPlayers[i]);
        }
        return _topPlayers;

        
    }
}