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

	float diff;

	GameObject playerPosition;
	GameObject[] objectPositions;
	GameObject[] slopePositions;

	void Start () {
		SetDefaults();
			
		isReadyToPlay = true;
}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (!dead) {
				GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().ShowGameplayUI();
				move = true;
			}
		}


		if (move && !dead) {
			if (speed < startSpeed) {				
				speed += startAcceleration * Time.deltaTime;
			}
			speed += acceleration * Time.deltaTime;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			diff = ray.origin.x - transform.position.x;

			//Debug.Log(Mathf.Abs(diff));
			transform.Translate(new Vector3(diff * 0.05f ,0, speed * Time.deltaTime));
		}
		score = bonusScore + (int) (transform.position.z / 10);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Object") {
			Die();
		} else if (other.gameObject.tag == "BonusPoint") {
			if (other.GetComponent<Coin>()) {
				int coins = PlayerPrefs.GetInt("coins");
				coins++;
				PlayerPrefs.SetInt("coins", coins);
				GameObject gameplayUI = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().gameplayUI;
				gameplayUI.GetComponent<GameplayUI>().ShowCoinWrapper();
			}
			other.gameObject.SetActive(false);
		}
	}

	void Die() {
		dead = true;

		//Animation

		// Show Game Over Menu
		GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().ShowGameOverScene(score);

	}

	public void Restart(bool _move) {
		SetDefaults();
		GameObject.Find("Object Spawner").gameObject.GetComponent<ObjectSpawner>().CreateClouds();
		GameObject.Find("Background Spawner").gameObject.GetComponent<BGSpawner>().CreateBackgrounds();
		transform.position = new Vector3(0f, transform.position.y, 0f);
		transform.FindChild("Trail").GetComponent<TrailRenderer>().Clear();
		bonusScore = 0;
		move = _move;
	}

	public void Reset() {
		Restart(false);
	}

	void SetDefaults() {
		speed = 0f;
		move = false;
		isReadyToPlay = true;
		dead = false;
	}
}
