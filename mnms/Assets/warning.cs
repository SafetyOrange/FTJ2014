using UnityEngine;
using System.Collections;

public class warning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.transform.position.x > -630f){
			if(transform.position.y < -20){
				transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
			}
		} 
	}
}
