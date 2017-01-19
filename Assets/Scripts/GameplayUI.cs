using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUI : MonoBehaviour {

	[SerializeField] Text txtScore;

	void Update() {
		txtScore.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().score.ToString();
	}

}
