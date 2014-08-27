using UnityEngine;
using System.Collections;

public class HeadRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Input.gyro.attitude;
	
	}
}
