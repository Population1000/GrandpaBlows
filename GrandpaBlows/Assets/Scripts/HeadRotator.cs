using UnityEngine;
using System.Collections;

public class HeadRotator : MonoBehaviour {

	private Vector3 rot;

	// Use this for initialization
	void Start () {
	
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		rot.x = (-1)*Input.gyro.attitude.z;
		rot.y = Input.gyro.attitude.w;
		rot.z = (-1)*Input.gyro.attitude.y;
		rot.w = Input.gyro.attitude.x;
*/
		/*
		rot.x = -Input.gyro.attitude.eulerAngles.y;
		rot.y = Input.gyro.attitude.eulerAngles.x;
		rot.z = Input.gyro.attitude.eulerAngles.z;
		transform.eulerAngles = rot;
		*/
		transform.rotation = Input.gyro.attitude;
	
	}
}
