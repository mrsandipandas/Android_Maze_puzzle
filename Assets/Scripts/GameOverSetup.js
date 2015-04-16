#pragma strict
private var csScript : ConnectionDb;
private var dbConnect : ConnectionDb;
private var resultSet : ResultSet;
private var maze : Maze;
var theSkin : GUISkin;
var attempts : int;
var timeElasped : float; //used to represent the seconds
var mainCam : Camera;

function Awake()  
{  
	/*
    //Get the CSharp Script  for ConnectionDb
    csScript = this.GetComponent("ConnectionDb"); 
    dbConnect = csScript.getInstance();
  */ 
} 

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
	
	// This will create an object for ConnectionDb and get player details
	
	//Get the CSharp Script  for ConnectionDb
    csScript = this.GetComponent("ConnectionDb"); 
    dbConnect = csScript.getInstance();
	maze = dbConnect.getMazeFromPlayerMazeDetails(1);
	maze.Components.RemoveAt(4);
	//GUI.Label (new Rect (posX2, posY2, 250, 100), "Time Elapsed:   " + timeElasped + " sec" + dbConnect.pushMazeToPlayerMaze(1, maze));
	GUI.Label (new Rect (posX2, posY2, 250, 100), "Time Elapsed:   " + timeElasped + " sec");
}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}