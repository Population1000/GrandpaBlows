using UnityEngine;
using System.Collections;

public class reticleScript : MonoBehaviour {
	
	public GameObject grandpa;
	public GameObject gameLight;
	public Vector3 inhaleRate = new Vector3(0.0f,0.01f,0.01f);
	public Vector3 exhaleRate = new Vector3(0.0f,0.02f,0.02f);
	public float blowLength = 2.2f;
	public float maximumBlow = 1.5f;
	public float minimumBlow = .01f;
	public int numCandles;
	public bool mouseDown = false;
	public bool blowing = false;
	private float startingLightIntensity;
	// Use this for initialization
	void Start () {
		grandpa = GameObject.FindGameObjectWithTag ("MainCamera");
		transform.localScale = new Vector3(blowLength, transform.localScale.y, transform.localScale.z);
		startingLightIntensity = gameLight.light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(!blowing)
				mouseDown = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			blowing = true;
			mouseDown = false;
		}
		if (mouseDown)
			transform.localScale = transform.localScale + inhaleRate;
		else
			transform.localScale = transform.localScale - exhaleRate;
		if (transform.localScale.y > maximumBlow) {
			transform.localScale = new Vector3(blowLength, maximumBlow, maximumBlow);
			//GAME OVER!
		}
		if (transform.localScale.y < minimumBlow) {
			blowing = false;
			transform.localScale = new Vector3 (blowLength, minimumBlow, minimumBlow);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Flame"))
			if(blowing)
			{
				foreach(Transform child in other.transform){
					if(child.name == "Flame")
					{
						if(child.gameObject.activeSelf)
							gameLight.light.intensity = gameLight.light.intensity - (startingLightIntensity / numCandles);
						child.gameObject.SetActive(false);
					}
					else
						child.gameObject.SetActive(true);
				}
			}
	}
	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Flame"))
			if(blowing)
				foreach(Transform child in other.transform){
					if(child.name == "Flame")
					{
						if(child.gameObject.activeSelf)
							gameLight.light.intensity = gameLight.light.intensity - (startingLightIntensity / numCandles);
						child.gameObject.SetActive(false);
					}
					else
						child.gameObject.SetActive(true);
				}
	}
}
