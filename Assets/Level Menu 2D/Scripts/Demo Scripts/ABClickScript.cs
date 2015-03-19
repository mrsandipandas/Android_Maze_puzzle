using UnityEngine;
using System.Collections;

public class ABClickScript : MonoBehaviour {

	private Vector3 initialScale;

	void Awake()
	{

		LevelMenu2D.I.OnItemClicked += OnItemClicked;
	}

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnItemClicked (int itemIndex, GameObject itemObject)
	{


		//Debug.Log("Item Clicked");
		initialScale = itemObject.transform.localScale;
		//iTween.ScaleBy(itemObject, new Vector3(2f, 2f, 0f), 0.5f);
		if (itemIndex >= 0 && itemIndex <= 2)
		{
			iTween.ScaleBy(itemObject, iTween.Hash("x", 1.5f, "y", 1.5f, "time", 0.5f, "looptype", "none", "easetype", "easeInOutBack"));
			iTween.ScaleTo(itemObject, iTween.Hash("x", initialScale.x, "y", initialScale.y, "time", 0.5f, "easetype", "easeOutBack", "looptype", "none", "delay", 0.5f));
		} else if (itemIndex >= 3 && itemIndex <= 5)
		{
			iTween.ScaleTo(itemObject, iTween.Hash("x", 1.4f, "y", 1.4f, "time", 0.1f, "looptype", "none"));
			iTween.ScaleTo(itemObject, iTween.Hash("x", initialScale.x, "y", initialScale.y, "time", 0.1f, "delay", 0.1f, "looptype", "none"));
		}

	}
}
