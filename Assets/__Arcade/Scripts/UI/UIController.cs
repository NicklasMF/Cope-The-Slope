using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Arcade {
	public class UIController : MonoBehaviour {

		public GameObject mainMenu;
		public GameObject gameOverScene;
		public GameObject gameplayUI;

		void Awake() {
			if (!PlayerPrefs.HasKey("diamonds")) {
				PlayerPrefs.SetInt("diamonds", 0);
			}
			if (!PlayerPrefs.HasKey("coins")) {
				PlayerPrefs.SetInt("coins", 0);
			}
			if (!PlayerPrefs.HasKey("playername")) {
				PlayerPrefs.SetString("playername", "Nicklas");
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
			mainMenu.GetComponent<UI_MainMenu>().UpdateScore();
		}

	}
}