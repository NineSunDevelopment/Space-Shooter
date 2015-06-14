using UnityEngine;
using System.Collections;

[AddComponentMenu("Controll/SoundBySpeed")]
public class SoundBySpeed : MonoBehaviour {
	
	private AudioSource ads;
	private float maxPitch = 0, maxVolume = 0;
	
	// Use this for initialization
	void Awake () {
		ads = GetComponent<AudioSource>();
		
		maxVolume = ads.volume;
		maxPitch = ads.pitch;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		ads.volume = maxVolume * Mathf.Abs ( Input.GetAxis("Vertical") );
		ads.pitch = maxPitch * Mathf.Abs ( Input.GetAxis("Vertical") );
		
		if(Input.GetKey(KeyCode.LeftShift)) ads.pitch *= 2;
	}
}
