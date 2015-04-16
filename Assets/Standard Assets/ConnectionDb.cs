using UnityEngine;
using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


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
			Debug.Log ("Method result is null");
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

	public Maze getMazeFromPlayerMazeDetails(int player_id) {
		String query = 	"SELECT * FROM player_maze where player_id="+player_id+";";		
		ResultSet result = executeQuery(query);
		if (result == null) {
			Debug.Log("Method result is null");
		}
		Debug.Log ("In function getMazeFromPlayerMazeDetails");
		String json = (String)(result.getFirstColumnValue("player_maze_desc"));
		Debug.Log (json);
		JObject obj = JObject.Parse(json);
		JsonSerializer serializer = new JsonSerializer();
		Maze maze = (Maze)serializer.Deserialize(new JTokenReader(obj), typeof(Maze));
		return maze;
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



	public bool insertMasterElement(String element_name, String element_property, String element_max, String element_credits) {
		String query = "INSERT INTO master_element(element_name, element_property, element_max, element_credits) " +
			"VALUES ('" + element_name + "', '" + element_property + "', " + element_max + ", " +element_credits + ");";
		return executeNonQuery(query) >= 0;
	}

	public bool insertMasterMaze(String maze_desc) {
		String query = "INSERT INTO master_maze(maze_desc) " +
			"VALUES ('" + maze_desc + "');";
		return executeNonQuery(query) >= 0;
	}

	public bool insertMasterPlayer(String player_username, String player_password, String player_email) {
		String query = "INSERT INTO master_player(player_username, player_password, player_email) " +
			"VALUES ('" + player_username + "', '" + player_password + "', '" + player_email + "');";
		return executeNonQuery(query) >= 0;
	}

	public bool insertPlayerElement(String player_id, String element_id) {
		String query = "INSERT INTO player_element(player_id, element_id) " +
			"VALUES (" + player_id + ", " + element_id + ");";
		return executeNonQuery(query) >= 0;
	}
	public bool insertPlayerMaze(String player_id, String maze_id, String player_maze_desc, String player_maze_count_played, String player_maze_time_avg) {
		String query = "INSERT INTO player_maze(player_id, maze_id, player_maze_desc, player_maze_count_played, player_maze_time_avg) " +
			"VALUES (" + player_id + ", " + maze_id + ", '" + player_maze_desc + "', " + player_maze_count_played + ", '" + player_maze_time_avg +   "');";
		return executeNonQuery(query) >= 0;
	}

	public bool insertPlayerStats(String player_id, String player_stats_score, String player_stats_credits) {
		String query = "INSERT INTO player_stats(player_id, player_stats_score, player_stats_credits) " +
			"VALUES (" + player_id + ", " + player_stats_score + ", " + player_stats_credits + ");";
		return executeNonQuery(query) >= 0;
	}


	private int executeNonQuery(String query) {
		IDbConnection dbcon = null;
		IDbCommand dbcmd = null;
		Int32 noOfRowsEffected = -1;
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
			noOfRowsEffected = dbcmd.ExecuteNonQuery();
			Debug.Log("6");
		}
		catch(Exception e){
			Debug.Log(e.Message);
			Debug.Log(e.StackTrace);
		}
		finally{
			// clean up
			if(dbcmd != null) {
				dbcmd.Dispose ();
				dbcmd = null;
			}
			if(dbcon != null) {
				dbcon.Close ();
				dbcon = null;
			}
		}
		return noOfRowsEffected;
	}


}