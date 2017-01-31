using UnityEngine;
using System.Collections;

namespace Career {
	public class CameraScript : MonoBehaviour {

		GameObject player;
		Vector3 offset;

		void Start() {
			player = GameObject.FindGameObjectWithTag("Player");
			if (player != null) {
				offset = transform.position - player.transform.position;
			}
		}

		void LateUpdate() {
			if (player != null) {
				transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);
			}
		}

	}
}