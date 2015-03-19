using UnityEngine;
using System.Collections;

public class TRClicker : MonoBehaviour {

	private Vector3 initialScale;

	void Awake () {

		LevelMenu2D.I.OnItemClicked += HandleOnItemClicked;
		SwipeDetector.OnSwipeLeft += HandleOnSwipeLeft;
		SwipeDetector.OnSwipeRight += HandleOnSwipeRight;
	}

	void HandleOnSwipeRight ()
	{
		LevelMenu2D.I.gotoBackItem();
	}

	void HandleOnSwipeLeft ()
	{
		LevelMenu2D.I.gotoNextItem();
	}

	void HandleOnItemClicked (int itemIndex, GameObject itemObject)
	{
		//if (SwipeDetector.isSwiping) return;
		initialScale = itemObject.transform.localScale;
		//iTween.ScaleBy(itemObject, new Vector3(2f, 2f, 0f), 0.5f);
		if (itemIndex >= 0 && itemIndex <= 1)
		{
			iTween.ScaleBy(itemObject, iTween.Hash("x", 1.5f, "y", 1.5f, "time", 0.5f, "looptype", "none", "easetype", "easeInOutBack"));
			iTween.ScaleTo(itemObject, iTween.Hash("x", initialScale.x, "y", initialScale.y, "time", 0.5f, "easetype", "easeOutBack", "looptype", "none", "delay", 0.5f));
		} else if (itemIndex >= 2 && itemIndex <= 3)
		{
			iTween.ScaleTo(itemObject, iTween.Hash("x", 1.69f, "y", 1.73f, "time", 0.1f, "looptype", "none"));
			iTween.ScaleTo(itemObject, iTween.Hash("x", initialScale.x, "y", initialScale.y, "time", 0.1f, "delay", 0.1f, "looptype", "none"));
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
