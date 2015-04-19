#pragma strict

var mainCam : Camera;
var theSkin : GUISkin;
var attempts : int;
var timeElapsed : float;
var avgTime : float;
var coins : int;
var coin : Transform;
private var csScript : ConnectionDb;
private var dbConnect : ConnectionDb;
private var opponentMaze : MazeObject;
private var opponentID : int;
private var proc : boolean;


function Start () {
	
	csScript = this.GetComponent("ConnectionDb"); 
    dbConnect = csScript.getInstance();
    opponentID = PlayerPrefs.GetInt("currentOpponent");
    opponentMaze = dbConnect.getMazeFromPlayerMazeDetails(parseInt(opponentID)); 
    
	attempts = PlayerPrefs.GetInt("attempts");
	timeElapsed = PlayerPrefs.GetFloat("lastSession");
	timeElapsed = Mathf.Round(timeElapsed * 100f) / 100f;
	avgTime = opponentMaze.avgTime;
	coins = avgTime-timeElapsed-attempts+1;
	if (coins<=1) {coins = 1;}
	
	coin.position.x = mainCam.ScreenToWorldPoint (new Vector3(Screen.width*(0.35),0f,0f)).x;
	coin.position.y = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(0.34),0f)).y;
	
	var newAvgTime : float;
	newAvgTime = (avgTime*(opponentMaze.counter)+timeElapsed)/(opponentMaze.counter +1);
	newAvgTime = Mathf.Round(newAvgTime * 100f) / 100f;
	var newAvgTimeStr : String = newAvgTime + "";
	var counter : String = opponentMaze.counter + "";
	proc = dbConnect.updateMazeStats(opponentID, newAvgTimeStr, counter);
	var score : int = (1000 - parseInt(timeElapsed))/attempts;
	var userID : int = 2; //dbConnect.getUserID(PlayerPrefs.GetString("usrname"));
	proc = dbConnect.updatePlayerStats(userID, score, coins);
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
	GUI.Label (new Rect (posX2, posY2, 250, 100), "Time Elapsed:   " + timeElapsed + " sec");
	GUI.Label (new Rect (posX3, posY3, 250, 100), "Average Time:   " + avgTime + " sec");
	GUI.Label (new Rect (posX4, posY4, 250, 100), "Coins:   " + coins);
	
}