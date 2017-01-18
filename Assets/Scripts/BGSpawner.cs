using UnityEngine;
using System.Collections;

public class BGSpawner : MonoBehaviour {

	GameObject[] backgrounds;
	float lastZ;

	void Start() {
		GetBackgroundsAndSetLastY();
	}

	void GetBackgroundsAndSetLastY() {
		backgrounds = GameObject.FindGameObjectsWithTag("Background");
		lastZ = backgrounds[0].transform.position.z;

		for (int i = 1; i < backgrounds.Length; i++) {
			if (lastZ < backgrounds[i].transform.position.z) {
				lastZ = backgrounds[i].transform.position.z;
			}
		}
	}

	public void CreateBackgrounds() {
		//backgrounds = GameObject.FindGameObjectsWithTag("Background");
		backgrounds[0].transform.position = new Vector3(backgrounds[0].transform.position.x, backgrounds[0].transform.position.y, -20f);
			
		for (int i = 1; i < backgrounds.Length; i++) {
			backgrounds[i].transform.position = new Vector3(backgrounds[0].transform.position.x, backgrounds[0].transform.position.y, i * backgrounds[i].transform.localScale.z - 20f);
			backgrounds[i].SetActive(true);
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Background") {
			if (other.transform.position.z == lastZ) {
				Vector3 temp = other.transform.position;
				float height = backgrounds[0].transform.localScale.z;

				for (int i = 0; i < backgrounds.Length; i++) {
					if (!backgrounds[i].activeInHierarchy) {
						temp.z += height;

						lastZ = temp.z;

						backgrounds[i].transform.position = temp;
						backgrounds[i].SetActive(true);
					}
				}
			}
		}
	}

}
