using System;
using System.Collections.Generic;

public class LeaderBoard
{
    private List<PlayerData> _allPlayers = new();
    private List<PlayerData> _topPlayers = new();

    public LeaderBoard()
    {
        _allPlayers.AddRange(new List<PlayerData> { new PlayerData("Oleg", 123), new PlayerData("vasili", 333), new PlayerData("Armyashka", 777), new PlayerData("Petr", 1111), new PlayerData("Kolyan", 2345) });
    }

    public List<PlayerData> GetTopPlayers(ref int count)
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