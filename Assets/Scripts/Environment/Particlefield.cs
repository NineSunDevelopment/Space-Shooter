using UnityEngine;
using System.Collections;

[AddComponentMenu("Environment/Particle Field Generator")]
public class Particlefield : MonoBehaviour {
	
	public GameObject prefab;
	public GameObject player;
	
	void Awake () {
		if (prefab == null
		||	player == null) 
			this.enabled = false;
	}
	
	void Start(){
		StartCoroutine( "_FieldRespawn" );
	}
	
	
	IEnumerator _FieldRespawn () {
		Debug.Log("<color=blue>INFO</color>Generate starfield.");
		
		
		Vector3 po = player.transform.position;
		Vector3[] p = new Vector3[9];
		
		//XyZ
		p[0] = new Vector3( po.x + 40, -40, po.z - 40);
		p[1] = new Vector3( po.x + 40, -40, po.z + 00);
		p[2] = new Vector3( po.x + 40, -40, po.z + 40);
		p[3] = new Vector3( po.x + 00, -40, po.z - 40);
		p[4] = new Vector3( po.x + 00, -40, po.z + 00);
		p[5] = new Vector3( po.x + 00, -40, po.z + 40);
		p[6] = new Vector3( po.x - 40, -40, po.z - 40);
		p[7] = new Vector3( po.x - 40, -40, po.z + 00);
		p[8] = new Vector3( po.x - 40, -40, po.z + 40);
		
		foreach(Vector3 tp in p){
			
			Instantiate(prefab, tp, Quaternion.identity);
			
		}
		
		yield return new WaitForSeconds(4);
		StartCoroutine( "_FieldRespawn" );
	}
}
