using UnityEngine;
using System.Collections;

public class ColorSwitcherScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		iTween.ColorTo(gameObject, Color.red, 0.2f);
	}

	void OnMouseExit()
	{
		iTween.ColorTo(gameObject, Color.white, 0.2f);
	}
}
