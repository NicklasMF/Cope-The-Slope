using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Career {
	public class UI_MainMenu : MonoBehaviour {

		[SerializeField] Text txtCoins;
		[SerializeField] Text txtBestScore;
		[SerializeField] GameObject imgFinger;


		// Use this for initialization
		void Start () {
			UpdateScore();
		}

		public IEnumerator ShowFinger(float _seconds) {
			imgFinger.SetActive(false);
			yield return new WaitForSeconds(_seconds);

			imgFinger.SetActive(true);
		}

		public void UpdateScore() {
			txtBestScore.text = PlayerPrefs.GetInt("bestScore").ToString();
			txtCoins.text = PlayerPrefs.GetInt("coins").ToString();
		}

	}
}