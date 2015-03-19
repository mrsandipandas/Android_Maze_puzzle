using UnityEngine;
using System.Collections;

public class BackToMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		AutoInitScript.I.indexToLoad = Application.loadedLevel-1;
		Application.LoadLevel(0);

	}

}
