using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Career {
	public class UI_MainMenu : MonoBehaviour {

		[SerializeField] Text txtCoins;
		[SerializeField] Text txtDiamonds;
		[SerializeField] Text txtPlayername;

		// Use this for initialization
		void Start () {
			UpdateScore();
		}

		public void UpdateScore() {
			txtPlayername.text = PlayerPrefs.GetString("playername").ToString();
			txtDiamonds.text = PlayerPrefs.GetInt("diamonds").ToString();
			txtCoins.text = PlayerPrefs.GetInt("coins").ToString();
		}

	}
}