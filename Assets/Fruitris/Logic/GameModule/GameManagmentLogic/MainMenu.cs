using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [Inject]
    private readonly GameStateHandler _gameStateHandler;

    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private TMP_InputField _nameInput;

    private string _playerName = "Noname"; 

    private void Start()
    {
        _startButton.onClick.AddListener(() => _gameStateHandler.GameStart(_playerName));
        _nameInput.onEndEdit.AddListener((string name) => ChangeName(_nameInput.text));
    }

    public void ChangeName(string playerName)
    {
        _playerName = playerName;
        _startButton.onClick.RemoveListener(() => _gameStateHandler.GameStart(_playerName));
        _startButton.onClick.AddListener(() => _gameStateHandler.GameStart(_playerName));
    }
}
