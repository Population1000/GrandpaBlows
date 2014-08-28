using UnityEngine;
using System.Collections;

public class BlowOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		Debug.Log ("Collided");
		if (c.tag == "Flame") {
			foreach(Transform child in c.transform){
				if(child.name == "Flame")
					child.gameObject.SetActive(false);
				else
					child.gameObject.SetActive(true);
			}
				}
	}
}
