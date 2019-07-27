using UnityEngine;
using System.Collections;
using System.Linq;

namespace Career {
	public class PlayerMovement : MonoBehaviour {

		// Skills //
		public int skillTurning = 2;


		public float acceleration = 0.5f;
		public float startAcceleration = 8f;
		public float startSpeed = 10f;
		public float speed = 0f;
		public bool move = false;
		public bool isReadyToPlay = false;
		public bool dead = false;
		float time = 0f;
		int portsReached = 0;

		float startPos, endPos, diffPos;

		[SerializeField] GameObject smokeTrail;
		GameObject[] smokeTrails;
		GameObject[] portArray;
		
		float diff;
		
		void Start () {
			SetDefaults();
			smokeTrails = GameObject.FindGameObjectsWithTag("TrailDust");
			foreach(GameObject trail in smokeTrails) {
				trail.SetActive(false);
			}
			isReadyToPlay = true;
		}
			
		void Update () {
			// Be Ready //
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
				if (!dead) {
					//GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().ShowGameplayUI();
					move = true;
				}
			}


			if (Input.GetMouseButtonDown(0)) {
				startPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin.x;
			}

			if (Input.GetMouseButton(0)) {
				endPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin.x;
				diffPos = endPos - startPos;
				transform.Rotate(new Vector3(0, diffPos * skillTurning, 0));
				startPos = endPos;
			}

			if (Input.GetMouseButtonUp(0)) {
				endPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin.x;
				diffPos = endPos - startPos;
				transform.Rotate(new Vector3(0, diffPos * skillTurning, 0));
				startPos = 0;
			}


			// Ved Bevægelse //
			if (move && !dead) {
				time += Time.deltaTime;

				if (speed < startSpeed) {
					speed += startAcceleration * Time.deltaTime;
				}
				speed += acceleration * Time.deltaTime;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				diff = ray.origin.x - transform.position.x;

				transform.Translate(transform.forward * speed * Time.deltaTime);
				//transform.Translate(new Vector3(diff * 0.05f ,0, speed * Time.deltaTime));

				// Hvis man misser en port //
				if (portArray.Length != portsReached) {
					if (transform.position.z - 3 > portArray[portsReached].transform.position.z) {
						Debug.Log("Dead");
						Die();
					}
				}

			}

		}

		void OnTriggerEnter(Collider other) {
			if (other.gameObject.tag == "Port") {
				portsReached++;
			}
		}

		void Die() {
			dead = true;

			//Animation
		}

		public void Restart() {
			SetDefaults();
			transform.position = new Vector3(0f, transform.position.y, 0f);
			transform.Find("Trail").GetComponent<TrailRenderer>().Clear();
			time = 0f;
			portsReached = 0;
			move = false;
		}

		public void Reset() {
			Restart();
		}

		void SetDefaults() {
			portArray = GameObject.FindGameObjectsWithTag("Port").OrderBy(go => go.transform.position.z).ToArray();
			speed = 0f;
			move = false;
			isReadyToPlay = true;
			dead = false;
		}
	}
}