﻿using UnityEngine;
using System.Collections;

namespace Arcade {
public class Coin : MonoBehaviour {

	[SerializeField] float rotatingSpeed = 20f;
	
	void Update () {
		transform.Rotate(0,rotatingSpeed*Time.deltaTime,0);
	}
}
}