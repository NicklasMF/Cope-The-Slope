using UnityEngine;
using System.Collections;

public class DebugPlayerPos : MonoBehaviour {

	[SerializeField] GameObject playerPrefab;
	[SerializeField] GameObject cameraPrefab;

	void Start() {
		if (GameObject.FindGameObjectWithTag("Player") == null) {
			Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
			Instantiate(cameraPrefab, cameraPrefab.transform.position, cameraPrefab.transform.rotation);
		}	
	}
}
