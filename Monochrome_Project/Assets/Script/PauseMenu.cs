using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenu;

	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
		}

	}

	public void ResumeMenu()
	{
		pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
	}
}
