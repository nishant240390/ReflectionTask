using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization

	public int radius;
	public float pie_angle;

	public Transform paddle_transform;

	 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float mousePosition_X=	Input.mousePosition.x;
		float temp=(mousePosition_X/Screen.width)*26 -13;
		Vector2 actual = new Vector2(temp,this.transform.position.y);
		float clampped_x= Mathf.Clamp (actual.x,-11,11);
		actual.x = clampped_x;
		this.transform.position = actual;
		paddle_transform = this.transform;
	}
}
