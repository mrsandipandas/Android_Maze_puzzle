#pragma strict

var movementSpeed_x : float = 0;
var movementSpeed_y : float = 0;
var speed : float = 20;
var force : float = 9.8;
var record : boolean;
var currentTime : float;

function Start () {
	currentTime = .0;
	StartRecord();
}

function FixedUpdate () {

	var dir = new Vector2(Input.acceleration.x, Input.acceleration.y);
	Physics2D.gravity = dir * force;
	if (record) {
		currentTime += 1*Time.deltaTime;
	}
}


function OnCollisionEnter2D (colInfo : Collision2D) {
	if (colInfo.collider.tag == "Exit") {
		PlayerPrefs.SetFloat("lastSession", currentTime);
		Application.LoadLevel("GameCompleted");
	}
	
	else if (colInfo.collider.tag == "Hole") {
		PlayerPrefs.SetFloat("lastSession", currentTime);
		Application.LoadLevel("GameOver");
	}
	
}

function StartRecord() {
	record = true;
}
