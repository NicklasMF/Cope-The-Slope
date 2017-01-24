using UnityEngine;
using System.Collections;

namespace Arcade {
public class BGCollector : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Background") {
			other.gameObject.SetActive(false);
		}
	}

}
}