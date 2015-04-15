using System;
using System.Collections.Generic;

public class Coordinate
{
	public double x { get; set; }
	public double y { get; set; }
	public bool z { get; set; }
}

public class Component
{
	public string Element { get; set; }
	public List<Coordinate> Coordinates { get; set; }
}

public class Maze
{
	public List<Component> Components { get; set; }
}
