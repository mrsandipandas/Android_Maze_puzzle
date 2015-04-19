using UnityEngine;
using System;
using System.Collections;
public class ResultSet {
	private ArrayList headers;
	private ArrayList rowList;

	public ResultSet () {
	}

	public ResultSet (ArrayList headers, ArrayList rowList) {
		this.headers = headers;
		this.rowList = rowList;
	}

	public void setHeaders (ArrayList headers) {
		this.headers = headers;
	}

	public void setRowsList(ArrayList rowList) {
		this.rowList = rowList;
	}

	public ArrayList getHeaders() {
		return headers;
	}

	public ArrayList getRowsList() {
		return rowList;
	}
	public String getHeadersInTxtFormat(){
		if (headers == null) {
			return null;
		}
		String result = "";
		foreach (String header in headers) {
			result += header +"  ";
		}
		Debug.Log ("Headers : " + result);
		return result;
	}

	public String getRowListInTxtFormat(){
		if (rowList == null) {
			return null;
		}
		String result = "";
		foreach (object[] row in rowList) {
			foreach (object column in row) {
				result += Convert.ToString(column) + " ";
			}
			result += "\n";
		}
		Debug.Log ("Data : " + result);
		return result;
	}

	public IList getColumnValues(String columnName) {
		int index = getColumnIndex (columnName);
		ArrayList columnValues = new ArrayList ();
		foreach (object[] row in rowList) {
			columnValues.Add(row[index]);
		}
		return columnValues;
	}

	// Use this function with column name to retrieve column value when single row is returned.
	public String getFirstColumnValue(String columnName) {
		int index = getColumnIndex (columnName);
		if (index == -1) {
			return null;
		}
		object[] row = (object[])rowList.ToArray () [0];
		return (String)(row[index]);
	}

	public int getFirstColumnValueInt(String columnName) {
		int index = getColumnIndex (columnName);
		object[] row = (object[])rowList.ToArray () [0];
		return (int)(row[index]);
	}


	public int getColumnIndex(String columnName) {
		int index = -1;
		foreach(String header in headers) {
			if(columnName.Equals(header)) {
				index = headers.IndexOf(header);
				break;
			}
		}
		return index;
	}


}