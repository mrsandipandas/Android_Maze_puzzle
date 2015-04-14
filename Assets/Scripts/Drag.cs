using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {
	public Transform mazeObject;
	private Transform selection = null;
	private Vector3 dist; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches)
		{
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			RaycastHit point;

			switch (touch.phase) 
			{
				case TouchPhase.Began:
				if(Physics.Raycast(ray, out hit, 100))
				{	
					if (hit.rigidbody !=null)
					{
					selection = hit.rigidbody.transform;
					mazeObject.transform.position = hit.point;
					}
				}
				dist = new Vector3(hit.rigidbody.transform.position.x,hit.rigidbody.transform.position.y,hit.rigidbody.transform.position.z) -  hit.point ;
				mazeObject.GetComponent<Collider>().enabled = true;
					break;
				case TouchPhase.Moved:
				int layerMask = 1 << 8;
				if(Physics.Raycast(ray, out point, 100,layerMask))
				{
					selection.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
					selection.transform.position = point.point + dist;
				}
					break;
				case TouchPhase.Ended:
				selection.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				selection = null;
				mazeObject.GetComponent<Collider>().enabled = false;
					break;
			}
		}
	}
}
