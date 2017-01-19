using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Background") {
			other.gameObject.SetActive(false);
		}
	}

}
