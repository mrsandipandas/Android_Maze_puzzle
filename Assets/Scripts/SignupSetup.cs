using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class SignupSetup : MonoBehaviour {

	private string username;
	private string email;
	private string password;
	private string confirmpass;
	private bool confirmpassMissing = false;
	private bool usernameNotvalid = false;
	private bool usernameNotUnique = false;
	private bool passNotValid = false;
	private bool passNotMatching = false;
	private bool displayErorrs = false;
	private ConnectionDb conn;
	public GUISkin mainSkin;
	
	void Start () {
		conn = ConnectionDb.getInstance();
	}

	public void UserInput(InputField userField) {
		username = userField.text;
	}

	public void PswInput(InputField passField) {
		password = passField.text;
	}

	public void ConPassInput(InputField conPassField) {
		confirmpass = conPassField.text;
	}

	public void EmailInput(InputField emailField) {
		email = emailField.text;
	}

	public void Signup () {
		confirmpassMissing = false;
		usernameNotvalid = false;
		usernameNotUnique = false;
		passNotValid = false;
		passNotMatching = false;
		if (CheckUserInput ()) {
			Register (username, password, email);
			PlayerPrefs.SetString ("usrname", username);
			ChangeScene ("MainMenu");
		} else {
			displayErorrs = true;
		}
	}

	//there should be a sql injection control
	public bool CheckUserInput() {
		if (username==null || username.Length<3) {
			usernameNotvalid = true;
			return false;
		}
		if (conn.checkAvailability(username)) {
			usernameNotUnique = true;
			return false;
		}
		if (password==null || password.Length<6) {
			passNotValid = true;
			return false;
		}
		if (confirmpass==null) {
			confirmpassMissing = true;
			return false;
		}
		if (!password.Equals(confirmpass)) {
			passNotMatching = true;
			return false;
		}
		return true;
	}
	
	public void Register(string uname, string pass, string eml) {   
		conn.insertMasterPlayer (uname, pass, eml);
	}

	public void ChangeScene (string scene) {
		Application.LoadLevel(scene);
	}

	void OnGUI () {
		GUI.skin = mainSkin;
		if (displayErorrs) {
			if (usernameNotvalid) {
				GUI.Label (new Rect (Screen.width/2-180, 150, 400, 70), "Username must be at least 3 alphanumeric digits!");
			}
			if (usernameNotUnique) {
				GUI.Label (new Rect (Screen.width/2-180, 150, 400, 70), "Username already existing!");
			}
			if (passNotValid) {
				GUI.Label (new Rect (Screen.width/2-180, 150, 400, 70), "Password must be at least 6 alphanumeric digits!");
			}
			if (confirmpassMissing) {
				GUI.Label (new Rect (Screen.width/2-180, 150, 400, 70), "Confirm password is missing!");
			}
			if (passNotMatching) {
				GUI.Label (new Rect (Screen.width/2-180, 180, 400, 50), "Passwords are not matching!");
			}
		}
	}

}