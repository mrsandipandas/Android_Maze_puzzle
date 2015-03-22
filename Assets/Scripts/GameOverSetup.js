#pragma strict

var theSkin : GUISkin;
var attempts : int;
var timeElasped : float; //used to represent the seconds
var mainCam : Camera;


function Start () {

	//these info should be fetched from the db
	timeElasped = 100f;
	attempts = 5;
	
}


function OnGUI () {

	var posX1 = mainCam.ScreenToWorldPoint (new Vector3(Screen.width*(50*0.25),0f,0f)).x;
	var posX2 = posX1;
	var posY1 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.5),0f)).y;
	var posY2 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.6),0f)).y;

	GUI.skin = theSkin;
	GUI.Label (new Rect (posX1, posY1, 200, 100), "Attempts:   " + attempts);
	GUI.Label (new Rect (posX2, posY2, 250, 100), "Time Elapsed:   " + timeElasped + " sec");
	
}