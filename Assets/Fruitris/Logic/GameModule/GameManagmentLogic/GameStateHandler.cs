using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameStateHandler
{
    public static PlayerData _currentPlayer = null;

    static GameStateHandler()
    {
        
    }
    public static void CreatePlayer(PlayerData data)
    {
        PlayerSaveHandler.SavePlayerInfo(data);
       LeaderBoard.AddPlayerToAllPlayers(data);
        _currentPlayer = data;
    }
    public static void GameStart()
    {
        if(_currentPlayer == null)
        {
            CreatePlayer(new("Noname", 0));
        }
        SceneManager.LoadScene("GameplayScene");
    }

    public static void GameOver()
    {
        
    }
}