 using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	public Transform pt;
	public Transform ct; 

	
	// Update is called once per frame
	void Update () {
		ct.position = Vector3.Lerp(
			ct.position, 
			new Vector3 (pt.position.x, ct.position.y, ct.position.z) , 1f); 
	
	}
}
