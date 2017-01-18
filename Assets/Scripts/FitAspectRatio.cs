using UnityEngine;
using System.Collections;

public class FitAspectRatio : MonoBehaviour {

	[SerializeField] GameObject slopeBlock;

	void Start() {
		float newWidth = slopeBlock.transform.localScale.x * Screen.height / Screen.width * 0.5f;

		Camera.main.orthographicSize = newWidth;
		//gameObject.transform.localScale = new Vector3(width, 1f, width);

	}
}
