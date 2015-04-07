using UnityEngine;
using System;
using System.Data;
using MySql.Data.MySqlClient;

public class ConnectionDb : MonoBehaviour
{
	public String message = "Hello";

	public static ConnectionDb instance = null;

	public static ConnectionDb getInstance() {
		if (instance == null) {
			instance = new ConnectionDb ();
		}
		return instance;
	}

	public String getTestMessage() {
		return message;
	}

	public String getElementDetails()
	{
//		string connectionString =
//			"Server=db4free.net;" +
//				"Database=mazzle;" +
//				"User ID=mazzle123;" +
//				"Password=m@zzl#" +
//				"Pooling=false";
		string connectionString =
			"Server=sql3.freemysqlhosting.net;" +
			"Port=3306;" +
			"Database=sql373249;" +
			"uid=sql373249;" +
			"Pwd=mF6%dS7%;";
		IDbConnection dbcon = new MySqlConnection(connectionString);
		dbcon.Open();
		IDbCommand dbcmd = dbcon.CreateCommand();
		// requires a table to be created named employee
		// with columns firstname and lastname
		// such as,
		//        CREATE TABLE employee (
		//           firstname varchar(32),
		//           lastname varchar(32));
		string sql =
			"SELECT element_id, element_name " +
				"FROM master_element";
		dbcmd.CommandText = sql;
		IDataReader reader = dbcmd.ExecuteReader();
		String output = "";
		while(reader.Read()) {
			string Element_id = (string) reader["element_id"];
			string Element_name = (string) reader["element_name"];
			output += "Name: " +
			                  Element_id + " " + Element_name+"\n";
		}
		// clean up
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbcon.Close();
		dbcon = null;

		return output;
	}
}