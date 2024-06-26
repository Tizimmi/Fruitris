using UnityEditor;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public static class GameStateHandler
{
    public static PlayerData _currentPlayer ;

    public static void CreatePlayer(PlayerData data)
    {
        PlayerSaveHandler.SavePlayerInfo(data);
        _currentPlayer = data;
    }
    public static void GameStart()
    {
        if (_currentPlayer == null)
        {
            CreatePlayer(new("Noname", 0));
        }
        SceneManager.LoadScene("GameplayScene");
    }

    public static void GameOver()
    {
        if(LeaderBoard._allPlayers.Contains(_currentPlayer) == false)
        {
            LeaderBoard.AddPlayerToAllPlayers(_currentPlayer);  
        }
        SceneManager.LoadScene(2);
        LeaderBoard.ShowLeaderboard();
    }

    public static void GameRestart()
    {

    }

    public static void GameQuit()
    {
        SaveGameData();
        Application.Quit();
    }

    public static void SaveGameData()
    {
        _currentPlayer?.SavePlayerData();
        LeaderBoard.SaveLeaderBoard();
    }

    public static void ClearPlayer()
    {
        _currentPlayer = null;
    }
}