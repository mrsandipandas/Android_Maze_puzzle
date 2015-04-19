#pragma strict

//Reference the db objects
private var csScript : ConnectionDb;
private var dbConnect : ConnectionDb;
private var opponentID : int;
private var currentUser : String;


function Start () {
	csScript = this.GetComponent("ConnectionDb"); 
    dbConnect = csScript.getInstance();
    //currentUser = PlayerPrefs.GetString("usrname");  
    currentUser = "user2"; //to be replaced by the one above
	opponentID = dbConnect.getRandomOpponentID(currentUser); 
}

function FindRandomOpponent () {
	PlayerPrefs.SetInt("currentOpponent", opponentID);	
	ChangeScene("Play");
}

function SearchByUserOpponent () {
	opponentID = dbConnect.getUserID(PlayerPrefs.GetString("opponent"));
	if (opponentID!=null) {
		PlayerPrefs.SetInt("currentOpponent", opponentID);
		ChangeScene("Play");
	} //it should be displayd and error in case the username it's not found
}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}