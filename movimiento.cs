using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Input.GetKey("a"))
		{ 
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-700f * Time.deltaTime, 0));
			gameObject.GetComponent<Animator> ().SetBool ("moving", true);
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		}
		if(Input.GetKey("d"))
		{ 
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (700f * Time.deltaTime, 0));
			gameObject.GetComponent<Animator> ().SetBool ("moving", true);
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
				}
		if(!Input.GetKey("a") && !Input.GetKey("d"))
		{ gameObject.GetComponent<Animator> ().SetBool ("moving", false);
		//gameObject.GetComponent<Animator> ().SetBool ("Jumping", false);
		}
		if(Input.GetKeyDown("w"))
		{
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0 , 700f));
			gameObject.GetComponent<Animator> ().SetBool ("moving", true);
		}
        else if(Input.GetKeyDown("s"))
        {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0 , -700f));
			gameObject.GetComponent<Animator> ().SetBool ("moving", true);
        }

    }
}
