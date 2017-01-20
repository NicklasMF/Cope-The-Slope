using UnityEngine;
using System.Collections;

public class ObjectCollector : MonoBehaviour {

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Object" || coll.tag == "BonusPoint") {
			coll.gameObject.SetActive(false);
		}
	}
}
