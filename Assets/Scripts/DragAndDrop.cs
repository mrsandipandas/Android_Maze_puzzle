using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	[SerializeField]
	// Use this for initialization
	float horizontal = 2.5f, vertical = 2.5f, dragSpeed = 0.1f;
	Transform cachedTransform;
	Vector2 startingPos;
	Object cloned;

	
	void Start ()
	{
		cachedTransform = transform;
		startingPos = cachedTransform.position;
	}
	
	void Update ()
	{
		if (Input.touchCount > 0) {
			Vector2 deltaPosition = Input.GetTouch (0).deltaPosition;

			switch (Input.GetTouch (0).phase) {
			case TouchPhase.Began:
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit)) {
					cloned = Instantiate (hit.transform.gameObject, transform.position, Quaternion.identity);
				}
			
				break;
			case TouchPhase.Moved:
				Debug.Log ("Touch Moved");
				DragObject (deltaPosition);
				break;

			case TouchPhase.Ended:
				//if(cloned.remaining == 0)
				//	Destroy(cloned);
				float x = cachedTransform.position.x;
				float y = cachedTransform.position.y;
				break;
			}
		}
	}

	void DragObject(Vector2 deltaPosition)
	{

		//cachedTransform.position = new Vector2 ((deltaPosition.x * dragSpeed) + cachedTransform.position.x, (deltaPosition *
		//	dragSpeed) + cachedTransform.position.y);
		cachedTransform.position = new Vector3 (Mathf.Clamp ((deltaPosition.x * dragSpeed) + cachedTransform.position.x,
				startingPos.x - horizontal, startingPos.x + horizontal),
		        Mathf.Clamp ((deltaPosition.y * dragSpeed) + cachedTransform.position.y,
		        startingPos.y - vertical, startingPos.y + vertical),
		                                       0.0f);
	}
		void OnCollisionEnter2D (Collision2D colInfo) {
		if ((colInfo.collider.tag == "SafePath" || colInfo.collider.tag == "Hole" || colInfo.collider.tag == "Exit"
		     || colInfo.collider.tag == "Hole") && Input.GetTouch (0).phase==TouchPhase.Ended) {
			cachedTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		}
		
		}
}