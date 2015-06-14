using UnityEngine;
using System.Collections;

public class MG : MonoBehaviour {
	
	public GameObject projectile;
	public float fireRate = 0.25f;
	public int magSize = 30;
	public float reloadTime = 1;
		
	private float nextShot = 0;
	public int shotsLeft = 0;
	public float reloadLeft = 0;
	
	public AudioClip sound;
	[Range(0,3)]
	public float pitch = 3;
	[Range(0,1)]
	public float volume = 0.3f;
	private AudioSource audioSource;
	
	void Awake() {
		shotsLeft = magSize;
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = sound;
		audioSource.pitch = pitch;
		audioSource.volume = volume;
	}
	
	// Update is called once per frame
	void Update () {
		nextShot -= Time.deltaTime;
		
		if(( shotsLeft > 0 || magSize == 0)
		&& nextShot <= 0
		&& Input.GetMouseButton(0)){
			nextShot = fireRate;
			if(magSize != 0) shotsLeft -= 1;
			audioSource.Play();
			Instantiate(projectile, transform.position, transform.rotation);
		}
		
		if(magSize != 0){
			if(shotsLeft <= 0 
			&& reloadLeft <= 0){
				reloadLeft = reloadTime;
			}
			
			if(shotsLeft <= 0
		   	&& reloadLeft > 0){
				reloadLeft -= Time.deltaTime;
			}
			
			if(shotsLeft <= 0
		   	&& reloadLeft <= 0){
				reloadLeft = reloadTime;
				shotsLeft = magSize;
			}
		}
	}
}
