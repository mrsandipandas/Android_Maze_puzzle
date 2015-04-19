using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputFinder : MonoBehaviour {

	private string username;
	public GUISkin mainSkin;
	private bool showError = false;
	private ConnectionDb conn;
	private int userID;

	void Start () {
		conn = ConnectionDb.getInstance ();
	}
	
	void Update () {
	
	}

	public void SearchUser () {
		if (CheckUsername ()) {
			PlayerPrefs.SetString ("currentOpponent", username);
			ChangeScene ("Play");
		} else {
			showError = true;
		}
	}

	public void UsernameInput(InputField uname) {
		username = uname.text;
	}

	public void ChangeScene (string scene) {
		Application.LoadLevel(scene);
	}

	public bool CheckUsername() {
		userID = conn.getUserID (username);
		if (userID > 0) {
			return true;
		}
		return false;
	}

	void OnGUI () {
		GUI.skin = mainSkin;
		if (showError) {
			GUI.Label (new Rect (Screen.width/2-180, 180, 400, 50), "User not found!");
		}
	}
}
