#pragma strict

var movementSpeed_x : float = 0;
var movementSpeed_y : float = 0;
var speed : float = 20;

function Start () {

}

function FixedUpdate () {
	//movementSpeed_x = Input.acceleration.x * speed;
	//movementSpeed_y = Input.acceleration.y * speed;
    //GetComponent.<Rigidbody2D>().velocity = new Vector2(movementSpeed_x, movementSpeed_y);
    Physics.gravity = new Vector3(Input.acceleration.x, Input.acceleration.y, 0);
}