﻿#pragma strict

function Start () {

}

function Update () {

}

function ChangeScene (scene : String) {
	Application.LoadLevel(scene);
}

function ChangeUser () {
	PlayerPrefs.DeleteAll();
	ChangeScene ("Login");
}