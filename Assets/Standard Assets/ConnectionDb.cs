using UnityEngine;
using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

public class ConnectionDb : MonoBehaviour
{

	//		string connectionString =
	//			"Server=db4free.net;" +
	//				"Database=mazzle;" +
	//				"User ID=mazzle123;" +
	//				"Password=m@zzl#" +
	//				"Pooling=false";
	
	private String connectionString =  	"Server=sql3.freemysqlhosting.net;" +
							  	"Port=3306;" + "Database=sql373249;" +
								"uid=sql373249;" + "Pwd=mF6%dS7%;";
	public static ConnectionDb instance = null;

	public static ConnectionDb getInstance() {
		if (instance == null) {
			instance = new ConnectionDb ();
		}
		return instance;
	}

	public ResultSet getElementDetails() {
		String query = 	"SELECT * FROM master_element;";
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		return result;
	}

	public ResultSet getMazeDetails() {
		String query = 	"SELECT * FROM master_maze;";
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		return result;
	}

	public ResultSet getPlayerDetails() {
		String query = 	"SELECT * FROM master_player;";
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		return result;
	}

	public ResultSet getPlayerElementDetails() {
		String query = 	"SELECT * FROM player_element;";
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		return result;
	}
	
	public ResultSet getPlayerMazeDetails() {
		String query = 	"SELECT * FROM player_maze;";
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		return result;
	}
	
	public ResultSet getPlayerStats() {
		String query = 	"SELECT * FROM player_stats;";
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		return result;
	}

	private ResultSet executeQuery(String query) {
		IDbConnection dbcon = null;
		IDbCommand dbcmd = null;
		IDataReader reader = null;
		ResultSet result = null;
		try{
			Debug.Log("1");
			dbcon = new MySqlConnection(connectionString);
			Debug.Log("2");
			dbcon.Open();
			Debug.Log("3");
			dbcmd = dbcon.CreateCommand();
			Debug.Log("4");
			dbcmd.CommandText = query;
			Debug.Log("5");
			reader = dbcmd.ExecuteReader();
			Debug.Log("6");
			// Read headers
			ArrayList headers = new ArrayList();
			Debug.Log("7");
			Debug.Log("Field Count : " +  reader.FieldCount);
			for(int i=0; i<reader.FieldCount; i++) {
				headers.Add(reader.GetName(i));
				Debug.Log("Field Name at position " + i + " is " +  reader.GetName(i));
			}
			Debug.Log("8");
			// Read data
			ArrayList rowList = new ArrayList();
			while (reader.Read()) {
				object[] values = new object[reader.FieldCount];
				reader.GetValues(values);
				rowList.Add(values);
			}
			Debug.Log("9");
			result = new ResultSet(headers, rowList);
			if (result == null) {
				Debug.Log("Base result is null");
			}
		}
		catch(Exception e){
			Debug.Log(e.Message);
			Debug.Log(e.StackTrace);
		}
		finally{
			// clean up
			if(reader != null) {
				reader.Close ();
				reader = null;
			}
			if(dbcmd != null) {
				dbcmd.Dispose ();
				dbcmd = null;
			}
			if(dbcon != null) {
				dbcon.Close ();
				dbcon = null;
			}
		}
		return result;
	}
}