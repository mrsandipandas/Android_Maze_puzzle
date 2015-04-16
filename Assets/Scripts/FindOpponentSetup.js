#pragma strict

static var opponentID : String = "0";

function Start () {

}

function Update () {

}

function FindRandomOpponent () {
	//opponentID = //getting random id from db;
	opponentID = "2";
	
	ChangeScene("Play");
}

function SearchByUserOpponent () {
	//opponentID = the text in the input field ;
	opponentID = "2";
	
	ChangeScene("Play");
}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}