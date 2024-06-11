using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private TMP_InputField _nameInput;

    private void Start()
    {
        _nameInput.onEndEdit.AddListener(CreateName);
        _startButton.onClick.AddListener(GameStateHandler.GameStart);
    }

    private void CreateName(string name)
    {
        GameStateHandler.CreatePlayer(new(name, 0));
        print(name);
    }

}
