using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameStateHandler : MonoBehaviour
{
    public PlayerData _currentPlayer; //??
    private void Start()
    {

    }
    
    public void CreatePlayer(PlayerData data)
    {
        PlayerSaveHandler.SavePlayerInfo(data);
       LeaderBoard.AddPlayerToAllPlayers(data);
        _currentPlayer = data;
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameplayScene");
        print(_currentPlayer.Nickname);
    }

    public void GameOver()
    {

    }
}