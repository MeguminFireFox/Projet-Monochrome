using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject pauseMenu;

    public void PlayGame()
	{
		SceneManager.LoadScene("Célia");
	}

	public void ReturnMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}

	
}
