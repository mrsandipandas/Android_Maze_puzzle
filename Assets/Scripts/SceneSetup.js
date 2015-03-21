#pragma strict

//Reference the camera
var mainCam : Camera;

//Reference the colliders we are going to adjust
var topWall : BoxCollider2D;
var bottomWall : BoxCollider2D;
var leftWall : BoxCollider2D;
var rightWall : BoxCollider2D;

//Reference the Ball and the ExitPause Button
var Ball : Transform;
var Exit : Transform;

function Start () { //Only set this to Update if you know the screen size can change during a playsession.

	Screen.orientation = ScreenOrientation.LandscapeLeft;

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
	Ball.position.x = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*(0.8), 0f, 0f)).x;
	Ball.position.y = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*(0.8), 0f)).y;
	Exit.position.x = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width*(0.3), 0f, 0f)).x;
	Exit.position.y = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height*(0.3), 0f)).y;
}