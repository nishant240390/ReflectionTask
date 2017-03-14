using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPaddle : MonoBehaviour {

	// Use this for initialization

	public int radius;
	public float pie_angle;
	private Vector3 scale;
	private Vector3 position;
	private float PI =Mathf.PI;



	void Start () {
		scale = this.transform.localScale;
		scale.x = 2*radius;
		scale.y = 2*radius;
		position = recalcluate_origin (this.transform.position);
		//print (this.transform.localScale);
		this.transform.position = position;
		this.transform.localScale = scale;
	}
	// Update is called once per frame
	void Update () {

		float mousePosition_X=	Input.mousePosition.x;
		float temp=(mousePosition_X/Screen.width)*26 -13;
		Vector2 actual = new Vector2(temp,this.transform.position.y);
		float clampped_x= Mathf.Clamp (actual.x,-11,11);
		actual.x = clampped_x;
		this.transform.position = actual;
	}

	Vector3 recalcluate_origin(Vector3 paddle_center){

		float angle_cal = pie_angle;
		angle_cal = angle_cal * .5f;
		float rad = (angle_cal/ 180f) * PI;
		float shiftedY=radius*(Mathf.Cos(rad))*-1;
		//print ("shifted y"+shiftedY);
		return new Vector3 (paddle_center.x,paddle_center.y+shiftedY,paddle_center.z);
	}
}
