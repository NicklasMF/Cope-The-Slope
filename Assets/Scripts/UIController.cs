using UnityEngine;
using System.Collections;

namespace Career {
public class UIController : MonoBehaviour {

		[SerializeField] GameObject uiMenu;
		[SerializeField] GameObject uiMainMenu;
		[SerializeField] GameObject uiSectionPlay;
		[SerializeField] GameObject uiGameOverScene;
		[SerializeField] GameObject uiGameplay;

		void Start() {
			HideAll();

			uiMenu.SetActive(true);
			uiMainMenu.SetActive(true);
		}

		void HideAllMenus() {
			uiMainMenu.SetActive(false);
			uiSectionPlay.SetActive(false);
		}

		void HideAll() {
			HideAllMenus();
			uiMenu.SetActive(false);
			uiGameOverScene.SetActive(false);
			uiGameplay.SetActive(false);
		}

		public void ShowSectionPlay() {
			HideAllMenus();
			uiSectionPlay.SetActive(true);
		}

		public void ShowGameOverScene(int score) {
			uiGameplay.SetActive(false);
			uiGameOverScene.SetActive(true);
			uiGameOverScene.GetComponent<UI_GameOver>().SetGameOverScene(score);
		}

		public void ShowGameplayUI() {
			uiMenu.SetActive(false);
			uiGameplay.SetActive(true);
			uiGameOverScene.SetActive(false);
		}

		public void ShowMainMenu() {
			uiMenu.SetActive(true);
			uiGameplay.SetActive(false);
			uiGameOverScene.SetActive(false);
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Reset();
			//StartCoroutine(mainMenu.GetComponent<UI_MainMenu>().ShowFinger(3f));
			//mainMenu.GetComponent<UI_MainMenu>().UpdateScore();
		}

	}
}