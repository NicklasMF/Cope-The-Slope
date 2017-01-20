using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject gameOverScene;
	public GameObject gameplayUI;

	void Awake() {
		if (!PlayerPrefs.HasKey("bestScore")) {
			PlayerPrefs.SetInt("bestScore", 0);
		}

		if (!PlayerPrefs.HasKey("coins")) {
			PlayerPrefs.SetInt("coins", 0);
		}
	}

	void Start() {
		if (gameOverScene.activeSelf == true) {
			gameOverScene.SetActive(false);
		}
		if (gameplayUI.activeSelf == true) {
			gameplayUI.SetActive(false);
		}

		mainMenu.SetActive(true);
		StartCoroutine(mainMenu.GetComponent<UI_MainMenu>().ShowFinger(0f));
		PlayerPrefs.SetInt("seenFinger", 1);
	}

	public void ShowGameOverScene(int score) {
		gameplayUI.SetActive(false);
		gameOverScene.SetActive(true);
		gameOverScene.GetComponent<GameOverController>().SetGameOverScene(score);
	}

	public void ShowGameplayUI() {
		mainMenu.SetActive(false);
		gameplayUI.SetActive(true);
		gameOverScene.SetActive(false);
	}

	public void ShowMainMenu() {
		mainMenu.SetActive(true);
		gameplayUI.SetActive(false);
		gameOverScene.SetActive(false);
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Reset();
		StartCoroutine(mainMenu.GetComponent<UI_MainMenu>().ShowFinger(3f));
		mainMenu.GetComponent<UI_MainMenu>().UpdateScore();
	}

}
