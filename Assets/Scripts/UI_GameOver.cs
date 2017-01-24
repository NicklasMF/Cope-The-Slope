using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Career {
public class UI_GameOver : MonoBehaviour {

	[SerializeField] Text txtScore;
	[SerializeField] Text txtBest;

	public void SetGameOverScene(int score) {
		txtScore.text = score.ToString();
		if (score > PlayerPrefs.GetInt("bestScore")) {
			// New Best //
			PlayerPrefs.SetInt("bestScore", score);
		}

		txtBest.text = PlayerPrefs.GetInt("bestScore").ToString();
	}

	public void RestartGame() {
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
		gameObject.SetActive(false);
		//GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().gameplayUI.SetActive(true);
	}
}
}