#pragma strict

var mainCam : Camera;
var theSkin : GUISkin;
var score : int;
var credits : int;
var gamesPlayed : int;
var gamesWon : int;
var succRate : float;
var rank : String;
var coin : Transform;
private var csScript : ConnectionDb;
private var dbConnect : ConnectionDb;
private var lastOpponentID : int;
private var lastOpponent : String;
private var stats : PlayerStats;

function Start () {
	csScript = this.GetComponent("ConnectionDb"); 
    dbConnect = csScript.getInstance();
	var userID : int = 2; //dbConnect.getUserID(PlayerPrefs.GetString("usrname")); 
	stats = dbConnect.getPlayerStats(userID);
	credits = stats.credits;
	score = stats.score;
	gamesWon = stats.gamesWon;
	gamesPlayed = stats.gamesPlayed;
	rank = dbConnect.getPlayerRank(userID);
	succRate = (parseFloat(gamesWon)/parseFloat(gamesPlayed))*100f;
	succRate = Mathf.Round(succRate * 100f) / 100f;
	coin.position.x = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*(0.33), 0f, 0f)).x;
	coin.position.y = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*(0.61), 0f)).y;
}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}

function OnGUI () {

	var posX1 = mainCam.ScreenToWorldPoint (new Vector3(Screen.width*(50*0.25),0f,0f)).x;
	var posY1 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.35),0f)).y;
	var posX2 = posX1;
	var posY2 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.43),0f)).y;
	var posX3 = posX1;
	var posY3 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.51),0f)).y;
	var posX4 = posX1;
	var posY4 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.59),0f)).y;
	var posX5 = posX1;
	var posY5 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.67),0f)).y;
	var posX6 = posX1;
	var posY6 = mainCam.ScreenToWorldPoint (new Vector3(0f,Screen.height*(50*0.75),0f)).y;
	
	GUI.skin = theSkin;
	GUI.Label (new Rect (posX1, posY1, 250, 100), "Total Score:   "+score);
	GUI.Label (new Rect (posX2, posY2, 250, 100), "Coins:   "+credits);
	GUI.Label (new Rect (posX3, posY3, 250, 100), "Games Played:   "+gamesPlayed);
	GUI.Label (new Rect (posX4, posY4, 250, 100), "Games Won:   "+gamesWon);
	GUI.Label (new Rect (posX5, posY5, 250, 100), "Success Rate:   "+succRate+" %");
	GUI.Label (new Rect (posX6, posY6, 250, 100), "Rank:   "+rank);
	
}