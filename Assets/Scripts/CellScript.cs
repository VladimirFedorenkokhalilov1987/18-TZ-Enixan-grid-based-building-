using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CellScript : MonoBehaviour 
{
	#region Cells ruls(Position, empty or not), use as value in Dictionary
	private Color32 fullColor = new Color32(255,118,118,255);
	private Color32 emptyColor = new Color32(96,255,90,255);

	private MeshRenderer meshRenderer;

	public bool isEmpty
	{
		get;
		set;
	}

	public Point GridPosition
	{
		get;
		set;
	}

	void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer> ();
	}

	public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
	{
		isEmpty = true;
		this.GridPosition = gridPos;
		transform.position = worldPos;
		transform.SetParent (parent);
		Grid.Instance.Cells.Add (gridPos, this);
	}

	private void ColorCell(Color newColor)
	{
		meshRenderer.material.color = newColor;
	}

	private void OnMouseOver()
	{
		if (!EventSystem.current.IsPointerOverGameObject()&& GameManager.Instance.ClickedButton!=null) 
		{
			if (isEmpty) 
			{
				ColorCell (emptyColor);
			} 

			if (!isEmpty) {
				ColorCell (fullColor);
			} 
			else if (Input.GetMouseButtonDown (0))
			{
				Grid.Instance.gridHolder.SetActive (false);
				Grid.Instance.grided = false;
				Grid.Instance.shopped = false;
				PlaceGoods();
				Hover.Instance.Deactivate();
			}
		}
	}

	private void OnMouseExit()
	{
		ColorCell (Color.white);
	}

	private void PlaceGoods()
	{
		Quaternion rotation;

		if(GameManager.Instance.ClickedButton.GoodPrefab.name == "PlantPot")
		 rotation = Quaternion.Euler(-90, 0, 0);
		else
			rotation = Quaternion.Euler(0, 0, 0);

		GameObject Good = (GameObject)Instantiate (GameManager.Instance.ClickedButton.GoodPrefab, transform.position, rotation);
		Good.transform.SetParent (Grid.Instance.insnstaledByPlayer.transform);
		isEmpty = false;
		ColorCell (Color.white);
		GameManager.Instance.BuyGoods ();
	}
	#endregion
}
