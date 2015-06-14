using UnityEngine;
using System.Collections;

[AddComponentMenu("Controll/EmitionBySpeed")]
public class EmitionBySpeed : MonoBehaviour {
	
	private ParticleSystem ps;
	private float maxEmission = 0;
	
	// Use this for initialization
	void Awake () {
	
		ps = GetComponent<ParticleSystem>();
		
		maxEmission = ps.startSize;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		ps.startSize = maxEmission * Mathf.Abs ( Input.GetAxis("Vertical") );
		
	}
}
