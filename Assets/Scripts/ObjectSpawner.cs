using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	[SerializeField] GameObject[] collectables;

	float minDistanceBetweenObjects = 3f;
	float maxDistanceBetweenObjects = 7f;
	float minX, maxX;
	float lastObjectPositionZ;
	float controlX;
	GameObject[] objects;
	GameObject player;

	void Start() {
		objects = GameObject.FindGameObjectsWithTag("Object");
		SetMinAndMaxX();
		CreateClouds();

	}

	void Shuffle(GameObject[] arrayToShuffle) {
		for (int i = 0; i < arrayToShuffle.Length; i++) {
			GameObject temp = arrayToShuffle[i];
			int random = Random.Range(i, arrayToShuffle.Length);
			arrayToShuffle[i] = arrayToShuffle[random];
			arrayToShuffle[random] = temp;
		}
	}

	public void CreateClouds() {
		Shuffle(objects);
		float positionZ = 10f;
		for (int i = 0; i < objects.Length; i++) {
			Vector3 temp = objects[i].transform.position;
			temp.z = positionZ;
			temp.x = Random.Range(minX, maxX);
			lastObjectPositionZ = positionZ;
			objects[i].transform.position = temp;
			positionZ += Random.Range(minDistanceBetweenObjects, maxDistanceBetweenObjects);
		}
	}

	void SetMinAndMaxX() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Screen.height));
		maxX = bounds.x + 0.5f;
		minX = -bounds.x - 0.5f;
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Object") {
			if (other.transform.position.z == lastObjectPositionZ) {
				Shuffle(objects);
				//Shuffle(collectables);

				Vector3 temp = other.transform.position;

				for (int i = 0; i<objects.Length; i++) {
					if (!objects[i].activeInHierarchy) {

						temp.z += Random.Range(minDistanceBetweenObjects, maxDistanceBetweenObjects);
						temp.x = Random.Range(minX, maxX);

						lastObjectPositionZ = temp.z;
						objects[i].transform.position = temp;
						objects[i].SetActive(true);
						
					}
				}

			}
		}
	}

}
