using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool jumping, diving, accelerating, inair, stationary, earthbound, falling;
	Vector2 vel, acc, pos;
	GameObject g;
	float thisy, lasty;

	// Use this for initialization
	void Start () {


		g = GameObject.FindGameObjectWithTag ("Ground");
		jumping = false;
		diving = false;
		accelerating = false;
		inair = false;
		stationary = true;
		earthbound = true;
		inair = false;
		falling = false;
		thisy = -100f;
		lasty = -100f;
		//		vel = new Vector2 (0, 0);
//		acc = new Vector2 (0, 0);
//		pos = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {



//		if(Input.GetKeyDown ("f")){
//			accelerating = true;
//			
//		} else if(Input.GetKeyUp ("f")){
//			accelerating = false;
//		}
//		Debug.Log (Time.deltaTime + " - stopped: " + stopped + ", jumping: " + jumping + ", diving: " + diving + ", accelerating: " + accelerating);

	}

	void FixedUpdate(){

		if(thisy == -100f){
			thisy = transform.position.y;
		} else {
			lasty = thisy;
			thisy = transform.position.y;
		}

		if(jumping){
			if(lasty != -100f){
				float trend = thisy-lasty;
				if(trend<0) {
					jumping = false;
					falling = true;
				}
			}
		}


		if(transform.rotation.x<0){
			transform.Rotate(Vector3.right*Time.deltaTime);
		} else if (transform.rotation.x>0){
			transform.Rotate(Vector3.left*Time.deltaTime);
		}


		if(transform.rotation.y<0){
			transform.Rotate(Vector3.up*Time.deltaTime);
		} else if (transform.rotation.y>0){
			transform.Rotate(Vector3.down*Time.deltaTime);
		}

		if(transform.rotation.z<0){
			transform.Rotate(Vector3.forward*Time.deltaTime);
		} else if (transform.rotation.z>0){
			transform.Rotate(Vector3.back*Time.deltaTime);
		}

//		vel.y -= 1f;
//		vel += acc;
//		pos += vel;
//		acc = new Vector2 (0, 0);
//
//		transform.position = new Vector3 (pos.x, pos.y, 0);

//		// State 1 - stationary
//		stationary = true;
//		vel = new Vector2(0, 0);
//		// State 2 - moving
//		accelerating = true;
//		// State 3 - jumping
//		jumping = true;
//		// State 4 - diving
//		diving = true;
//		// State 5 - landing
//		diving = false;
//		jumping = false;


		if(Input.GetKeyDown ("a")){
			if(stationary || earthbound){
				accelerating = true;
				stationary = false;
			}
			if (jumping || falling){
				diving = true;
				jumping = false;
				falling = false;
			}
		}
		if(Input.GetKeyUp ("a")){
			if(accelerating){
				jumping = true;
				accelerating = false;
			}
			if(diving){
				diving = false;
				falling = true;
			}
			if(earthbound){
				accelerating = false;
			}
		}

		if(jumping){
			earthbound = false;
			vel = new Vector2(vel.x, 500f);
			if(!inair){
				rigidbody2D.AddForce(Vector3.up*vel.y);
				inair = true;
			}
		}

		if(diving){
			rigidbody2D.AddForce(Vector3.down*vel.y);
		}
		
		if(accelerating){
			vel = new Vector2(20f, vel.y);
		}
		
		if(!accelerating){
			if(vel.x>0){
				vel = new Vector2(vel.x-0.1f, vel.y);
			}
		}
		
		if(vel.x<=0){
			stationary = true;
		}



//		if(!stopped){
//		} else {
//			if(vel.x>0){
//				vel = new Vector2(vel.x-1, 0);
//			}
//		}
//
//		if(jumping && !inair){
//			Debug.Log("inair");
//			inair = true;
//			rigidbody2D.AddForce(Vector3.up*500f);
////			acc = new Vector2(0, 1);
//		}
//
//		if(diving){
//			Debug.Log("diving");
//			rigidbody2D.AddForce(Vector3.down*500f);
//		}
//
//		if(transform.position.y<-1.6f){
//			inair = false;
//			jumping = false;
//			diving = false;
//		}

		g.transform.Rotate (Vector3.forward * Time.deltaTime*vel.x);
		transform.position = new Vector3 (-3.7f, transform.position.y, transform.position.z);

	}

	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag == "Ground-Inner"){
			earthbound = true;
			inair = false;
			falling = false;
		}
	}
}
