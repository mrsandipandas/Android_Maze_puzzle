#pragma strict

var movementSpeed_x : float = 0;
var movementSpeed_y : float = 0;
var speed : float = 20;
var force : float = 9.8;

function Start () {

}

function FixedUpdate () {

	var dir = new Vector2(Input.acceleration.x, Input.acceleration.y);
	Physics2D.gravity = dir * force;
//	movementSpeed_x = Input.acceleration.x * speed;
//	movementSpeed_y = Input.acceleration.y * speed;
//  GetComponent.<Rigidbody2D>().velocity = new Vector2(movementSpeed_x, movementSpeed_y);
}