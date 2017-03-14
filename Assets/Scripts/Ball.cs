using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D ball;
	void Start () {
		Vector2 ini_velocity = new Vector2 (0f,-8f);
		ball = this.GetComponent<Rigidbody2D> ();
		ball.velocity=ini_velocity;
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
	
		//print ("collision");

		Vector2 twerk = new Vector2 (Random.Range(0f,3f),Random.Range(0f,0f));

	//	ball.velocity += twerk;

		Vector2 norm = col.contacts [0].normal;
		Vector2 reflect = Vector2.Reflect (ball.velocity,norm);
		ball.velocity = reflect;

	}
	void OnTriggerEnter2D(Collider2D collider1){
		print ("ontrigger");

		 
	}


}
