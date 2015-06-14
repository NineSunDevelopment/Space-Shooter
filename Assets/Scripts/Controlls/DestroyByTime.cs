using UnityEngine;
using System.Collections;



[AddComponentMenu("Controll/DestroyByTime")]
public class DestroyByTime : MonoBehaviour {
	
	public int amount = 0;
	public Unit unit;
	
	void Awake () {
	
		StartCoroutine( _DestroyIt(amount, unit) );
	
	}
	
	
	IEnumerator _DestroyIt(int a, Unit u) {
		
		if(a <= 0) a = 0;
		
		if(u == Unit.Milliseconds)
			yield return new WaitForSeconds(a / 1000);
		
		if(u == Unit.Seconds)
			yield return new WaitForSeconds(a);
		
		if(u == Unit.Minutes)
			yield return new WaitForSeconds(a * 60);
			
			
		Destroy(gameObject);
	}
	
	
	/*
	 * ENUM
	 */
	public enum Unit{
		Milliseconds,
		Seconds,
		Minutes
	};
}
