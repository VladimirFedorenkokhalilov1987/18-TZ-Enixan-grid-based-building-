using UnityEngine;
using System.Collections;

public struct Point  {
	#region Cell positions use in Dictionary as key
	public int X {
		get;
		set;
	}

	public int Y {
		get;
		set;
	}

	public int Z {
		get;
		set;
	}

	public Point(int x, int y, int z)
	{
		this.X = x;
		this.Y = y;
		this.Z=z;
	}
	#endregion
}
