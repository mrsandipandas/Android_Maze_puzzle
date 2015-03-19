using UnityEngine;
using System.Collections;

public class DemoSelectorClicker : MonoBehaviour {

	//Vector3 initScale = Vector3.zero;

	void Awake()
	{
		
		LevelMenu2D.I.OnItemClicked += OnItemClicked;
	}

	// Use this for initialization
	void Start () {
		//initScale = this.gameObject.transform.localScale;
	}

	void OnMouseEnter()
	{
		iTween.ColorTo(gameObject, Color.red, 0.2f);
		//iTween.ScaleTo(gameObject, new Vector3(0.6f, 0.6f), 0.2f);
	}
	

	void OnMouseExit()
	{
		iTween.ColorTo(gameObject, Color.white, 0.2f);
		//iTween.ScaleTo(gameObject, initScale, 0.2f);
	}

	void OnMouseUp () {
		if (this.name.Equals("hori_icon"))
		{
			LevelMenu2D.I.orientation = LevelMenu2D.MenuOrientation.Horizontal;
			LevelMenu2D.I.autoOffset = true;
			LevelMenu2D.I.itemOffset = Vector2.zero;
			LevelMenu2D.I.recreateMenu();
			AutoInitScript.I.demoType = this.name;
		} else if (this.name.Equals("diag_icon_1"))
		{
			LevelMenu2D.I.orientation = LevelMenu2D.MenuOrientation.Custom;
			LevelMenu2D.I.autoOffset = false;
			LevelMenu2D.I.itemOffset = new Vector2(4f, 4f);
			LevelMenu2D.I.recreateMenu();
			AutoInitScript.I.demoType = this.name;
		} else if (this.name.Equals("diag_icon_2"))
		{
			LevelMenu2D.I.orientation = LevelMenu2D.MenuOrientation.Custom;
			LevelMenu2D.I.autoOffset = false;
			LevelMenu2D.I.itemOffset = new Vector2(4f, -4f);
			LevelMenu2D.I.recreateMenu();
			AutoInitScript.I.demoType = this.name;
		} else if (this.name.Equals("verti_icon"))
		{
			LevelMenu2D.I.orientation = LevelMenu2D.MenuOrientation.Vertical;
			LevelMenu2D.I.autoOffset = true;
			LevelMenu2D.I.itemOffset = Vector2.zero;
			LevelMenu2D.I.recreateMenu();
			AutoInitScript.I.demoType = this.name;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int level) {
		if (level == 0)
			LevelMenu2D.I.initialItemNumber = AutoInitScript.I.indexToLoad;
		
	}

	void OnItemClicked (int itemIndex, GameObject itemObject)
	{
		
		
		//Debug.Log(itemIndex + " " + itemObject.name);
		Application.LoadLevel(itemIndex+1);
		AutoInitScript.I.indexToLoad = itemIndex;
		//LevelMenu2D.I.initialItemNumber = itemIndex;
	}
}
