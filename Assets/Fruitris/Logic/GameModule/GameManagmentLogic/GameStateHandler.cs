using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameStateHandler : MonoBehaviour
{
    [Inject]
    private readonly GamePrefabFactory _gamePrefabFactory;
    [SerializeField]
    private Player _player;

    private void Start()
    {

    }
    public void GameStart(string playerName)
    {
        SceneManager.LoadScene("GameplayScene");
        print(playerName);
        //_gamePrefabFactory.InstantiatePrefab<Player>(_player, gameObject.transform);
        _player.Nickname = playerName;

        _player.SavePlayer();
    }

    public void GameOver()
    {

    }
}