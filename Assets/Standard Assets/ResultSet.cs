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
				result += Convert.ToString(column) + "  ";
			}
			result += "\n";
		}
		Debug.Log ("Data : " + result);
		return result;
	}


}