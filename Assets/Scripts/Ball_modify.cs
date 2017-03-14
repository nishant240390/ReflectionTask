using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_modify : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D ball;
	public RealPaddle paddle;
	bool LAST_COLLISION_PADDLE;
	private float PI =Mathf.PI;
	int up = 1;
	int down=2;

	void Start () {
		Vector2 ini_velocity = new Vector2 (0f,-8f);
		ball = this.GetComponent<Rigidbody2D> ();
		ball.velocity=ini_velocity;
	}


	// Update is called once per frame
	void Update () {
		Vector2 paddle_center = new Vector2(paddle.transform.position.x,-5f);
		Vector2 ball_center = ball.transform.position;

		if (isCollision (paddle_center,ball_center)&&!LAST_COLLISION_PADDLE ) {

			Vector2 norm = findNormal(paddle_center,ball_center);
			norm = norm.normalized;
			Vector2 reflect = Vector2.Reflect (ball.velocity,norm);
			ball.velocity = reflect;
			LAST_COLLISION_PADDLE=true;
		}


	}

	void OnCollisionEnter2D(Collision2D col){
    	LAST_COLLISION_PADDLE=false;
		Vector2 norm = col.contacts [0].normal;
		Vector2 reflect = Vector2.Reflect (ball.velocity,norm);

		if (isVelocityUpward (ball.velocity)) {
			reflect = twerk (reflect, up);
		          
		} else {
		
			reflect = twerk (reflect,down);
		}
		ball.velocity = reflect;
	}
	bool isCollision(Vector2 paddle_center,Vector2 ball_center){
		paddle_center = recalcluate_origin (paddle_center);

		if (Vector2.Distance (paddle_center, ball_center) <= (paddle.radius + .5f)) {
			//print ("paddle= "+paddle_center);
			//print ("ball ="+ball_center);
			//print ("distace="+Vector2.Distance (paddle_center, ball_center));
			return true;
		}
		return false;
	}

	Vector2 findNormal(Vector2 paddle_center,Vector2 ball_center){
		paddle_center = recalcluate_origin (paddle_center);
		return ball_center - paddle_center;
	}
	 

	bool isVelocityUpward(Vector2 ball_velocity){

		if (ball_velocity.y > 0)
			return true;
		return false;
	}

	Vector2 twerk(Vector2 refl,int direction){
		if (direction == 1) {
		
		
		} else {
		
		
		}

		return refl;
	}
	Vector2 recalcluate_origin(Vector2 paddle_center){


		float angle_cal = paddle.pie_angle;
		angle_cal = angle_cal * .5f;
		float rad = (angle_cal/ 180f) * PI;
		float shiftedY=paddle.radius*(Mathf.Cos(rad))*-1;
		//print ("shifted y"+shiftedY);
		return new Vector2 (paddle_center.x,paddle_center.y+shiftedY);
	}
}
