using UnityEngine;
using System.Collections;

[AddComponentMenu("Controll/Shipcontroll")]
public class Shipcontroll : MonoBehaviour {
	
	public Camera cam;
	
	public float acc = 12;
	
	private Rigidbody rb;
	private float drag;
	
	void Awake() {
		rb = GetComponent<Rigidbody>();
		drag = rb.drag;
	}
	
	
	void Update () {
		Debug.Log("<color=blue>INFO</color> "+ Input.GetAxis("Mouse ScrollWheel"));
		float axis = Input.GetAxis("Mouse ScrollWheel");
		
		if((-axis > 0 && cam.transform.position.y > 3)
		|| (-axis < 0 && cam.transform.position.y < 30)) {
			cam.transform.position = new Vector3 (
				cam.transform.position.x,
				cam.transform.position.y + axis * 10,
				cam.transform.position.z
			);
		}
		
		if(cam.transform.position.y <= 3){
			cam.transform.position = new Vector3 (
				cam.transform.position.x,
				3,
				cam.transform.position.z
			);
		}
		
		if(cam.transform.position.y >= 30){
			cam.transform.position = new Vector3 (
				cam.transform.position.x,
				30,
				cam.transform.position.z
			);
		}
	}
	
	
	void FixedUpdate() {
		/*
		 * Rotation
		 */
		Vector2 mp = Input.mousePosition;
		Vector3 p = cam.ScreenToWorldPoint(new Vector3(mp.x, mp.y, cam.transform.position.y));
		
		p.y = 0;
		transform.position = new Vector3(
			transform.position.x,
			0,
			transform.position.z
		);
		
		
		transform.LookAt(p);
		cam.transform.position =new Vector3(
			transform.position.x,
			cam.transform.position.y,
			transform.position.z
			);
		
		
		/*
		 * Position
		 */
		rb.AddForce( transform.forward * Input.GetAxis("Vertical") * acc, ForceMode.Acceleration);
		
		
		/*
		 * Boost
		 */
		if(Input.GetKey(KeyCode.LeftShift)) {
			rb.drag = 2.5f;
		} else {
			rb.drag = drag;
		}
		
	}
}
