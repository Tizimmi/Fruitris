using System;
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

    private void Start()
    {
        _nameInput.onEndEdit.AddListener(CreateName);
        _startButton.onClick.AddListener(_gameStateHandler.GameStart);
    }

    private void CreateName(string name)
    {
        _gameStateHandler.CreatePlayer(new(name, 0));
        print(name);
    }

}
