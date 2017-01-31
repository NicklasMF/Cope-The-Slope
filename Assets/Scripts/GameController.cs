using UnityEngine;
using System.Collections;

namespace Career {
	public class GameController : MonoBehaviour {

		[SerializeField] GameObject playerPrefab;
		[SerializeField] GameObject cameraPrefab;

		Vector3 playerStartPos;

		void Awake() {
			//PlayerPrefs.DeleteAll();
			if (!PlayerPrefs.HasKey("coins")) {
				PlayerPrefs.SetString("playername", "Nicklas");
				PlayerPrefs.SetInt("coins", 0);
				PlayerPrefs.SetInt("diamonds", 0);
				PlayerPrefs.SetInt("skillSpeed", 5);
				PlayerPrefs.SetInt("skillAcceleration", 5);
				PlayerPrefs.SetInt("skillTurning", 5);

			}
		}

		void OnLevelWasLoaded() {
			playerStartPos = GameObject.FindGameObjectWithTag("PlayerStartPosition").transform.position;
			Instantiate(cameraPrefab, playerStartPos, Quaternion.identity);
			Instantiate(playerPrefab);
		}
	}
}
