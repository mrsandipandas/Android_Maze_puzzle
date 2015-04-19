using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LoginSetup : MonoBehaviour {

	private string username;
	private string password;
	public GUISkin mainSkin;
	private bool showError = false;
	private ConnectionDb conn;
	private int userID = -1;

	void Start () {
		conn = ConnectionDb.getInstance ();
		string userTemp = PlayerPrefs.GetString ("usrname");
		userID = conn.getUserID (userTemp);
		if (userID != -1) {
			ChangeScene ("MainMenu");
		}
	}

	public void authentication () {
		if (CheckData()) {
			PlayerPrefs.SetString("usrname", username);
			PlayerPrefs.Save();
			ChangeScene ("MainMenu");
		} else {
			showError = true;
		}
	}

	public void UserInput(InputField userField) {
		username = userField.text;
	}

	public void PassInput(InputField passfield) {
		password = passfield.text;
	}

	public void ChangeScene (string scene) {
		Application.LoadLevel(scene);
	}

	// should be added a security function for throttling and anti-sql injection
	public bool CheckData() {
		if (username == null || password == null) { return false; }
		string pswTemp;
		userID = conn.getUserID (username);
		if (userID >0) {
			pswTemp = conn.getUserPsw (userID);
			return password.Equals (pswTemp);
		}
		return false;
	}

	void OnGUI () {
		GUI.skin = mainSkin;
		if (showError) {
			GUI.Label (new Rect (Screen.width/2-180, 180, 400, 50), "Username or Password not valid!");
		}
	}
}
