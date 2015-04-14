using UnityEngine;
using System.Collections;

public class TestGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void testGameClick()
	{
		if(Input.GetButtonDown("TestGameBtn"))
		{
			Physics.gravity *= -1;
		}
	}

}
