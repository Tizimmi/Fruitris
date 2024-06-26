using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<Button>().onClick.AddListener(GoToMenu);
    }

	void GoToMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
		GameStateHandler.ClearPlayer();
	}
	
}
