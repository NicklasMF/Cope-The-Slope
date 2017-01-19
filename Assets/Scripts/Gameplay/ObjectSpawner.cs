using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {


	float minDistanceBetweenObjects = 3f;
	float maxDistanceBetweenObjects = 7f;
	[SerializeField] float collectableDistance = 25f;
	float minX, maxX;
	float lastObjectPositionZ, lastCollectablePositionZ;

	GameObject[] objects;
	GameObject[] collectables;
	GameObject player;

	void Start() {
		objects = GameObject.FindGameObjectsWithTag("Object");
		collectables = GameObject.FindGameObjectsWithTag("BonusPoint");
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
			temp = new Vector3(Random.Range(minX, maxX), 0 ,positionZ);
			lastObjectPositionZ = positionZ;
			objects[i].transform.position = temp;
			positionZ += Random.Range(minDistanceBetweenObjects, maxDistanceBetweenObjects);
		}
		CreateCollectables();
	}

	void CreateCollectables() {
		float positionZ = 30f;
		for (int i = 0; i < collectables.Length; i++) {
			Vector3 temp = collectables[i].transform.position;
			temp = new Vector3(Random.Range(minX, maxX), 0, positionZ + Random.Range(collectableDistance, collectableDistance * 2));
			lastCollectablePositionZ = positionZ;
			collectables[i].transform.position = temp;
			positionZ += Random.Range(collectableDistance, collectableDistance * 2);
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

				Vector3 temp = other.transform.position;

				for (int i = 0; i<objects.Length; i++) {
					if (!objects[i].activeInHierarchy) {

						temp.z += Random.Range(minDistanceBetweenObjects, maxDistanceBetweenObjects);
						temp.x = Random.Range(minX, maxX);
						temp.y = 0;

						lastObjectPositionZ = temp.z;
						objects[i].transform.position = temp;
						objects[i].SetActive(true);
						
					}
				}
			}
		} else if (other.tag == "BonusPoint") {
			if (other.transform.position.z == lastCollectablePositionZ) {
				Debug.Log("Bonus");
				Vector3 temp = other.transform.position;

				for (int i = 0; i<collectables.Length; i++) {
					if (!collectables[i].activeInHierarchy) {

						temp.z = Random.Range(collectableDistance, collectableDistance * 2);
						temp.x = Random.Range(minX, maxX);
						temp.y = 0;

						lastCollectablePositionZ = temp.z;
						collectables[i].transform.position = temp;
						collectables[i].SetActive(true);

					}
				}


			}
		}

	}

}
