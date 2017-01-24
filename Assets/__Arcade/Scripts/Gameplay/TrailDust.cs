using UnityEngine;
using System.Collections;

namespace Arcade {
public class TrailDust : MonoBehaviour {

	void OnEnable() {
		GetComponent<ParticleSystem>().Play();
		StartCoroutine(Disable());
	}

	IEnumerator Disable() {
		yield return new WaitForSeconds(2f);

		gameObject.SetActive(false);
	}
}
}