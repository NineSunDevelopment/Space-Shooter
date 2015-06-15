using UnityEngine;
using System.Collections;

public class EnergyShield : MonoBehaviour {	

	private float effectTime;
	private Renderer ren;
	private Color normalColor;
	public Color hitColor;
	
	void Awake(){
		ren = GetComponent<Renderer>();
		normalColor = ren.material.GetColor("_Color2");
	}
	
	void Update(){
		effectTime -= Time.deltaTime;
		
		ren.material.SetColor( "_Color2", Color.Lerp (normalColor, hitColor, effectTime) );
	}
	
	void OnCollisionEnter(Collision collision) {
		print ("MOTHA FUCKIN HIT!" );
		effectTime = 1;
		ren.material.SetColor( "_Color2", hitColor );
	}
}
