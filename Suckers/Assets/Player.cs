using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool pressed;
	float xSpeed, ySpeed;
	GameObject planet;


	// Use this for initialization
	void Start () {

		pressed=false;
		planet = GameObject.FindWithTag("Ground");

	}

	void Update () {

		CheckInput();
		HandleRotation();
		Glide();
		RotatePlanet();

	}

	void FixedUpdate(){

		rigidbody2D.velocity += new Vector2(0,-.1f);

	}


	void CheckInput(){

		if(Input.anyKey==true) pressed=true;
		//if(Input.GetTouch==true) pressed=true;			LOOK MA! MOBILE INPUT!
		else pressed = false;

	}

	void HandleRotation(){

						//Not pressed, tilt nose up
		if(!pressed){  
			if (transform.eulerAngles.z>=89 && transform.eulerAngles.z<100) transform.eulerAngles = new Vector3(0,0,89);
			else transform.Rotate(Vector3.forward * Time.deltaTime * 250);
		}
						//Pressed, tilt nose down
		else{
			if (transform.eulerAngles.z<=271 && transform.eulerAngles.z>100) transform.eulerAngles = new Vector3(0,0,271);
			else transform.Rotate(Vector3.back * Time.deltaTime * 200);
		}
	}

	void RotatePlanet(){
		xSpeed = rigidbody2D.velocity.x;
		planet.transform.Rotate(Vector3.forward * Time.deltaTime * 60 * xSpeed);
		rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

	}

	void Glide(){

		Vector2 direction = new Vector2();
		direction = GameObject.Find("Forward").transform.position - transform.position;
		rigidbody2D.AddForce(direction.normalized *10);

	}

}
