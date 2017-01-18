using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float acceleration = 0.1f;
	public float startAcceleration = 1f;
	public float startSpeed = 2f;
	public float speed = 0f;
	public bool move = false;
	public bool isReadyToPlay = false;
	public bool dead = false;

	public int score;
	private int bonusScore;

	GameObject playerPosition;
	GameObject[] objectPositions;
	GameObject[] slopePositions;

	void Awake() {
		if (!PlayerPrefs.HasKey("bestScore")) {
			PlayerPrefs.SetInt("bestScore", 0);
		}
	}

	void Start () {
		SetDefaults();
			
		isReadyToPlay = true;
}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			move = true;
		}

		if (move && !dead) {
			if (speed < startSpeed) {				
				speed += startAcceleration * Time.deltaTime;
			}
			speed += acceleration * Time.deltaTime;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float diff = ray.origin.x - transform.position.x;

			//Debug.Log(Mathf.Abs(diff));

			transform.Translate(new Vector3(diff * 0.05f ,0, speed * Time.deltaTime));
		}

		score = bonusScore + (int) (transform.position.z / 10);

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Object") {
			Die();
		}
	}

	void Die() {
		dead = true;

		//Animation

		// Show Game Over Menu
		GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().ShowGameOverScene(score);

	}

	public void Restart() {
		SetDefaults();
		GameObject.Find("Object Spawner").gameObject.GetComponent<ObjectSpawner>().CreateClouds();
		GameObject.Find("Background Spawner").gameObject.GetComponent<BGSpawner>().CreateBackgrounds();
		transform.position = new Vector3(0f, transform.position.y, 0f);
		move = true;
	}

	void SetDefaults() {
		speed = 0f;
		move = false;
		isReadyToPlay = true;
		dead = false;
	}
}
