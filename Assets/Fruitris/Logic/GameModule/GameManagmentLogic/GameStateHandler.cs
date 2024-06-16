using UnityEditor;
using UnityEngine.SceneManagement;

public static class GameStateHandler
{
    public static PlayerData _currentPlayer = null;

    public static void CreatePlayer(PlayerData data)
    {
        PlayerSaveHandler.SavePlayerInfo(data);
        LeaderBoard.AddPlayerToAllPlayers(data);
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
        SceneManager.LoadScene(2);
        LeaderBoard.ShowLeaderboard();
    }

    public static void GameQuit()
    {
        SaveGameData();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public static void SaveGameData()
    {
        _currentPlayer?.SavePlayerData();
        LeaderBoard.SaveLeaderBoard();
    }
}