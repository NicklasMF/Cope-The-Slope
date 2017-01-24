using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Arcade {
public class GameplayUI : MonoBehaviour {

	[SerializeField] Text txtScore;
	[SerializeField] GameObject coinWrapper;

	void Start() {
		coinWrapper.SetActive(false);
	}

	void Update() {
		txtScore.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().score.ToString();
	}

	public void ShowCoinWrapper() {
		coinWrapper.transform.Find("CoinScore").GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();
		coinWrapper.SetActive(true);
		StartCoroutine(HideCoinWrapper());
	}

	IEnumerator HideCoinWrapper() {
		yield return new WaitForSeconds(3f);

		coinWrapper.SetActive(false);
	}

}
}