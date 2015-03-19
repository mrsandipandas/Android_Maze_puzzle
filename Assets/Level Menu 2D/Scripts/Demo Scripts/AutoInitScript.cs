using UnityEngine;
using System.Collections;

public class AutoInitScript : Singleton<AutoInitScript> {

	public static AutoInitScript I {
		get {
			return (AutoInitScript) mInstance;
		} set {
			mInstance = value;
		}
	}

	public int indexToLoad = 0;
	public string demoType = "hori_icon";

	void Awake()
	{

		//Debug.LogWarning("Current: " + indexToLoad);
		//LevelMenu2D.I.gotoItem(indexToLoad);
	}

	// Use this for initialization
	void Start () {
		//Debug.LogWarning("Current: " + indexToLoad);
		//LevelMenu2D.I.gotoItem(indexToLoad);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
