using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : SingleTone<Grid>
{
	#region variables
	public GameObject insnstaledByPlayer;
	public GameObject[] cell;

	[SerializeField]
	public GameObject enviermentHolder;

	[SerializeField]
	public GameObject gridHolder;

	public Dictionary<Point, CellScript> Cells 
	{
		get;
		set;
	}

	public float CellSize 
	{
		get
		{
			return cell[0].GetComponent<MeshRenderer> ().bounds.size.x;	
		}
	}

	private int height=50;
	private int width=50;
	private GameObject[,] grid = new GameObject[50, 50];

	[SerializeField]
	private GameObject shopPanel;

	public bool shopped = false;

	public bool grided =false;
	#endregion

	#region Create level(Grid and random envierment)
	void Awake () 
	{
		CreateLevel ();
	}

	private void CreateLevel()
	{
		Cells = new Dictionary<Point, CellScript> ();

		GenerateUpEnv ();
		GenerateDownEnv ();

		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < height; z++) 
			{
				PlaceGrid ("0",x,z,this.transform.position);
			}
		}
	}

	void GenerateUpEnv()
	{
		for (int x = 0;x < 45; x+=2) 
		{
			for (int z = 45 ; z < 50; z+=2)  
			{
				GameObject envierments =(GameObject) Instantiate(cell[Random.Range(1,cell.Length)]);
				envierments.transform.position= new Vector3(this.transform.position.x+(CellSize*x),
					envierments.transform.position.y,this.transform.position.z+(CellSize*z));
				envierments.gameObject.transform.SetParent (enviermentHolder.transform);
			}
		}
	}

	void GenerateDownEnv () 
	{
		for (int x = 45;x < 50; x+=2) 
		{
			for (int z = 0 ; z < 50; z+=2)  
			{
				GameObject envierments =(GameObject) Instantiate(cell[Random.Range(1,cell.Length)]);
				envierments.transform.position= new Vector3(this.transform.position.x+(CellSize*x),
				envierments.transform.position.y,this.transform.position.z+(CellSize*z));
				envierments.gameObject.transform.SetParent (enviermentHolder.transform);
			}
		}
	}

	private void PlaceGrid(string cellType, int x, int z, Vector3 pos)
	{
		int cellIndex = int.Parse (cellType);

		GameObject gridPlane = (GameObject)Instantiate (cell[cellIndex]);
		grid [x, z]= gridPlane;

		gridPlane.GetComponent<CellScript>().Setup (new Point (x, 0, z),
		new Vector3 (this.transform.position.x+(CellSize*x),
		gridPlane.transform.position.y,
		this.transform.position.z+(CellSize*z)),
		gridHolder.transform);
		
		gridHolder.SetActive (false);
		grided = false;
	}
	#endregion

	#region Show and hide Grid/Shop panel
	public void ShowShopPanel()
	{
		if (!shopped) 
		{
			gridHolder.SetActive (true);
			shopPanel.SetActive (true);
			shopped = true;
			grided = true;
		} 
		else 
		{
			gridHolder.SetActive (false);
			shopPanel.SetActive (false);
			shopped = false;
			grided = false;
			Hover.Instance.Deactivate();
		}
	}

	public void ShowHideGrid()
	{
		if (!grided)
		{
			gridHolder.SetActive (true);
			grided = true;
		} 
		else 
		{
			gridHolder.SetActive (false);
			grided = false;
			shopPanel.SetActive (false);
			shopped = false;
			Hover.Instance.Deactivate();
		}
	}
	#endregion
}
