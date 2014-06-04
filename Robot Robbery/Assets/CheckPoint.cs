using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public int order;
	currentCheckpoint c;
	// Use this for initialization
	void Start () {
		c = FindObjectOfType<currentCheckpoint>();
	}
	
	// Update is called once per frame
	void Update () {
		if(order == c.current){
			renderer.enabled = true;
		} else {
			renderer.enabled = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
			if(renderer.enabled == true){
			Debug.Log ("collide!");
			if(other.gameObject.tag=="Player") {
				renderer.material.color = Color.green;
				c.current++;
			} else {
				renderer.material.color = Color.red;
			}
		}
	}

}
