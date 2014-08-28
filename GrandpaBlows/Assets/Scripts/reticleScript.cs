using UnityEngine;
using System.Collections;

public class reticleScript : MonoBehaviour {
	
	public GameObject grandpa;
	public Vector3 scaleRate = new Vector3(0.01f,0.0f,0.01f);
	public bool mouseDown = false;
	public bool blowing = false;
	// Use this for initialization
	void Start () {
		grandpa = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = grandpa.transform.rotation;
		transform.Rotate (Vector3.right * 270);
//		transform.position = grandpa.transform.position;
//		transform.Translate (Vector3.down * 1);
		if (Input.GetMouseButtonDown (0))
			mouseDown = true;
		if (Input.GetMouseButtonUp (0)) {
			blowing = true;
			mouseDown = false;
		}
		if (mouseDown)
			transform.localScale = transform.localScale + scaleRate;
		else
			transform.localScale = transform.localScale - scaleRate;
		if (transform.localScale.x < .01f) {
			blowing = false;
			transform.localScale = new Vector3 (0.01f, 0.8f, 0.01f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Flame"))
			if(blowing)
				Destroy(other.gameObject);
	}
	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Flame"))
			if(blowing)
				Destroy(other.gameObject);
	}
}
