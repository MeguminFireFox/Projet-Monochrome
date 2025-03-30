using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	public GameObject creditsMenu;

    public void PlayGame(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
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

	public void CreditsMenu()
	{
		creditsMenu.gameObject.SetActive(true);

		
	}

	private void Update()
	{
		if ((Input.GetKeyDown(KeyCode.Escape)) && (creditsMenu.activeInHierarchy))
		{
			creditsMenu.gameObject.SetActive(!creditsMenu.gameObject.activeSelf);
		}
	}
}
