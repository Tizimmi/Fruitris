using Fruitris.Logic.PlayerModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fruitris.Logic.GameModule.GameManagmentLogic
{
	public class MainMenu : MonoBehaviour
	{
		[SerializeField]
		private Button _startButton;
		[SerializeField]
		private Button _quitButton;
		[SerializeField]
		private TMP_InputField _nameInput;

		private void Start()
		{
			_nameInput.onEndEdit.AddListener(CreateName);
			_startButton.onClick.AddListener(GameStateHandler.GameStart);
			_quitButton.onClick.AddListener(GameStateHandler.GameQuit);
		}

		private void CreateName(string name)
		{
			GameStateHandler.CreatePlayer(new PlayerData(name, 0));
			print(name);
		}
	}
}