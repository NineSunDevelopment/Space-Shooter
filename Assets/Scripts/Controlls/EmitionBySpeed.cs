using UnityEngine;
using System.Collections;

[AddComponentMenu("Controll/EmitionBySpeed")]
public class EmitionBySpeed : MonoBehaviour {
	
	public GameObject PlayerShip;
	
	private ParticleSystem ps;
	private float maxEmission = 0;
	
	// Use this for initialization
	void Awake () {
		if(PlayerShip == null) this.enabled = false;
		ps = GetComponent<ParticleSystem>();

		maxEmission = ps.startSize;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log("<color=blue>INFO</color> "+ ps.startSize);
		ps.startSize = maxEmission * Mathf.Abs ( Input.GetAxis("Vertical") );
	}
}
