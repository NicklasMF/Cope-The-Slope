using UnityEngine;
using System.Collections;

namespace Arcade {
public class SlopeController : MonoBehaviour {

	public GameObject player;
	public GameObject snowSlope;
	public GameObject snowSlopeWrapper;

	void Update() {
		float checkSlope = player.transform.position.z + snowSlope.transform.localScale.z;
		if (!Physics.CheckSphere(new Vector3(player.transform.position.x, player.transform.position.y, checkSlope), 1f)) {
			Debug.Log("No Slope");
			Instantiate(snowSlope, snowSlopeWrapper.transform);
			//slope.transform.position = new Vector3(ch)
		}


	}

}
}