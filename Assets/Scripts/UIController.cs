using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject gameOverScene;
	public GameObject gameplayUI;

	void Start() {
		if (gameOverScene.activeSelf == true) {
			gameOverScene.SetActive(false);
		}

		gameplayUI.SetActive(true);
	}

	public void ShowGameOverScene(int score) {
		gameplayUI.SetActive(false);
		gameOverScene.SetActive(true);
		gameOverScene.GetComponent<GameOverController>().SetGameOverScene(score);
	}

}
