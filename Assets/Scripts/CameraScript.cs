using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	Vector3 offset;

	void Start() {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate() {
		transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);
	}

}
