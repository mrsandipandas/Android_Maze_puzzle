#pragma strict


function Start () {

}

function Update () {

}

function PathSelector (path : int) {
	PlayerPrefs.SetInt("safePath", path);
	ChangeScene("Editor_Sandbox");
}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}