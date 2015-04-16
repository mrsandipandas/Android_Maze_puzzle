#pragma strict
var mainCam : Camera;
var theSkin : GUISkin;
var attempts : int;
var timeElasped : float; //used to represent the seconds
var avgTime : float;
var coins : int;
var coin : Transform;


function Awake()  
{  
} 

function Start () {

	//these info should be fetched from the db
	attempts = 5;
	timeElasped = 100f;
	avgTime = 120f;
	coins = 200;
	
	coin.position.x = mainCam.ScreenToWorldPoint (new Vector3(Screen.width*(0.35),0f,0f)).x;
	coin.position.y = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(0.34),0f)).y;
}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}

function OnGUI () {

	var posX1 = mainCam.ScreenToWorldPoint (new Vector3(Screen.width*(50*0.25),0f,0f)).x;
	var posY1 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.4),0f)).y;
	var posX2 = posX1;
	var posY2 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.5),0f)).y;
	var posX3 = posX1;
	var posY3 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.6),0f)).y;
	var posX4 = posX1;
	var posY4 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.7),0f)).y;
	
	GUI.skin = theSkin;
	GUI.Label (new Rect (posX1, posY1, 200, 100), "Attempts:   " + attempts);
	GUI.Label (new Rect (posX2, posY2, 250, 100), "Time Elapsed:   " + timeElasped + " sec");
	GUI.Label (new Rect (posX3, posY3, 250, 100), "Average Time:   " + avgTime + " sec");
	GUI.Label (new Rect (posX4, posY4, 250, 100), "Coins:   " + coins);
	
}