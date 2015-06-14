using UnityEngine;
using System.Collections;

[AddComponentMenu("Environment/DestroyByBoundary")]
public class DestroyByBoundary : MonoBehaviour {

	Vector3 boundaries = new Vector3(700,100,700);
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		
		foreach(GameObject g in allObjects){
			if (g.activeInHierarchy){
				if(Mathf.Abs(g.transform.position.x) > boundaries.x
			   	|| Mathf.Abs(g.transform.position.y) > boundaries.y
				|| Mathf.Abs(g.transform.position.z) > boundaries.z){
					Destroy (g);
				}
			}	
		}
	}
}
