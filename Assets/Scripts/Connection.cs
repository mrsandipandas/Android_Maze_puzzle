using System;
using System.Data;
using MySql.Data.MySqlClient;

public class Test
{
	public static void Main(string[] args)
	{
		string connectionString =
			"Server=db4free.net;" +
				"Database=mazzle;" +
				"User ID=mazzle123;" +
				"Password=m@zzl#;" +
				"Pooling=false";
		IDbConnection dbcon;
		dbcon = new MySqlConnection(connectionString);
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
		while(reader.Read()) {
			string Element_id = (string) reader["element_id"];
			string Element_name = (string) reader["element_name"];
			Console.WriteLine("Name: " +
			                  Element_id + " " + Element_name);
		}
		// clean up
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbcon.Close();
		dbcon = null;
	}
}