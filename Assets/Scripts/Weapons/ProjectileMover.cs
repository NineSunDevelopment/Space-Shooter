using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour {

	public float mass = 1;
	public float initialVelocity = 150;
	
	private Rigidbody rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
		
		rb.mass = mass;
		rb.velocity = transform.forward * initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
