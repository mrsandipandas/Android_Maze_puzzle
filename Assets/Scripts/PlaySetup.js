#pragma strict

//Reference the camera
var mainCam : Camera;

//Reference the colliders we are going to adjust
var topWall : BoxCollider2D;
var bottomWall : BoxCollider2D;
var leftWall : BoxCollider2D;
var rightWall : BoxCollider2D;

//Reference the maze's objects
var Ball : Transform;
var Exit : Transform;
var LargeWall : Transform;
var SmallWall : Transform;
var LargeHole : Transform;
var SmallHole : Transform;
var rotating = false; 

//Reference the db objects
private var csScript : ConnectionDb;
private var dbConnect : ConnectionDb;
private var resultSet : ResultSet;
private var opponentMaze : MazeObject;
private var opponentID : int;
private var currentUser : String;


function Start () {
	
	PlayerPrefs.SetInt("attempts", PlayerPrefs.GetInt("attempts")+1);
	
	csScript = this.GetComponent("ConnectionDb"); 
    dbConnect = csScript.getInstance();
    //currentUser = PlayerPrefs.GetString("usrname");  
    currentUser = "user2"; //to be replaced by the one above
	opponentID = PlayerPrefs.GetInt("currentOpponent"); 

	//Move each wall to its edge location:
	topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
	topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y +0.5f -0.1f);
	
	bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
	bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f +0.15f);
	
	leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
	leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f + 0.1f, 0f);
	
	rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
	rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f -0.15f, 0f);
	
	LoadMaze();
}


function LoadMaze () {	
	
	opponentMaze = dbConnect.getMazeFromPlayerMazeDetails(parseInt(opponentID));
	
	var index : int;
	var indC : int;
	var objects = opponentMaze.mazeDescription.Components;
	for (index = 0; index < objects.Count; index++) {
		var pos = objects[index].Coordinates;
		//var posY = objects[index].Coordinates[0].y;
		//var rot = objects[index].Coordinates[0].z;
    	if (objects[index].Element=="Ball") {
    		Ball.position.x = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*(pos[0].x), 0f, 0f)).x;
			Ball.position.y = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*(pos[0].y), 0f)).y;
		}
		else if (objects[index].Element=="Exit") {
    		Exit.position.x = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*(pos[0].x), 0f, 0f)).x;
			Exit.position.y = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*(pos[0].y), 0f)).y;
		}
		else if (objects[index].Element=="LargeWall") {
			for (indC = 0; indC < objects[index].Coordinates.Count; indC++){
				SetObject (LargeWall, pos[indC].x, pos[indC].y, pos[indC].z);
			}
		}
		else if (objects[index].Element=="SmallWall") {
			for (indC = 0; indC < objects[index].Coordinates.Count; indC++){
				SetObject (SmallHole, pos[indC].x, pos[indC].y, pos[indC].z);
			}
		}
		else if (objects[index].Element=="LargeHole") {
			for (indC = 0; indC < objects[index].Coordinates.Count; indC++){
				SetObject (LargeHole, pos[indC].x, pos[indC].y, pos[indC].z);
			}
		}
		else if (objects[index].Element=="SmallHole") {
			for (indC = 0; indC < objects[index].Coordinates.Count; indC++){
				SetObject (SmallHole, pos[indC].x, pos[indC].y, pos[indC].z);
			}
		}
	}

//	SetObject (LargeWall, 0.7, 0.3, true);
//	SetObject (LargeWall, 0.3, 0.7, false);
//	SetObject (SmallWall, 0.5, 0.4, true);
//	SetObject (SmallWall, 0.25, 0.6, false);
//	SetObject (LargeHole, 0.2, 0.3, true);
//	SetObject (LargeHole, 0.8, 0.9, false);
//	SetObject (SmallHole, 0.15, 0.15, true);
//	SetObject (SmallHole, 0.15, 0.9, false);
	
}


function SetObject (object : Transform, x : float, y : float, toRotate : boolean) {

	var ObjectClone = Instantiate(object, transform.position, transform.rotation);
	ObjectClone.position.x = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*x, 0f, 0f)).x;
	ObjectClone.position.y = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*y, 0f)).y;
	
	if (toRotate) {
		RotateObject (ObjectClone, Vector3.forward*-90, 25); //This rotate the object by 90° clockwise
	}
	
}


function RotateObject (thisTransform : Transform, degrees : Vector3, rate : float) {
	//Higher the rate, faster the rotation -> 25 looks like instant rotation
    //if (rotating) return;
 
    rotating = true;
 
    var startRotation : Quaternion = thisTransform.rotation;
    var endRotation : Quaternion = thisTransform.rotation * Quaternion.Euler(degrees);
    var t : float = 0.0;
 
    while (t <= 1.0) {
    	t += Time.deltaTime * rate;
    	thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
    	yield;
	}
 
	rotating = false;
 
}


