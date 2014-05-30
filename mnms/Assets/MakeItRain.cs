using UnityEngine;
using System.Collections;

public class MakeItRain : MonoBehaviour {
	public Transform[] mnm;
	int i, j;
	AudioSource[] audios;
	AudioSource yum, ugh;
	Animator a;
	Animation ani;
	GameObject[] loses;
	// Use this for initialization
	void Start () {
		i = 0;
		j = 0;
		audios = Camera.main.GetComponents<AudioSource>();
		foreach (AudioSource clip in audios) {
			Debug.Log(clip.clip.name);
			if(clip.clip.name == "chomp_yum"){
				yum = clip;
			}
			if(clip.clip.name == "chomp_ugh"){
				ugh = clip;
			}
		}
		a = Camera.main.GetComponent<Animator>();
		a.enabled = false;
		ani = a.animation;
	}
	
	// Update is called once per frame
	void Update () {
		if(i<120){
			Transform m = Instantiate(mnm[j], new Vector3(-0.5f, 50f, 33f), Quaternion.identity) as Transform;
			if(j<mnm.Length-1){
				j++;
			} else {
				j=0;
				i++;
			}
		}

		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			   {
				if(hit.collider.gameObject.tag == "poisoned"){
					Debug.Log("you're dead");
					Destroy (hit.collider.gameObject);
					ugh.Play();
					CharacterController c = Camera.main.GetComponent<CharacterController>();
					MouseLook m = Camera.main.GetComponent<MouseLook>();
					c.enabled = false;
					m.enabled = false;
					a.enabled = true;
					a.SetBool("Dead", true );
					loses = GameObject.FindGameObjectsWithTag ("lose");
					int l = 0;
					foreach(GameObject sign in loses){
						if(sign.name == "tryagain"){
							sign.transform.position = new Vector3(Camera.main.transform.position.x+30, Camera.main.transform.position.y+150, Camera.main.transform.position.z);
						} else {
							sign.transform.position = new Vector3(Camera.main.transform.position.x+30, Camera.main.transform.position.y+150, Camera.main.transform.position.z+50);
						}
						l++;
					}

				} else if(hit.collider.gameObject.tag == "safe") {
					Debug.Log ("yum");
					Destroy (hit.collider.gameObject);
					yum.Play();
				} else if(hit.collider.gameObject.tag == "lose") {
					if(hit.collider.gameObject.name == "tryagain"){
						Application.LoadLevel ("bowl");
					}
				}
			}
		}
	}
}
