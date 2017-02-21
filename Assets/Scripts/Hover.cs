using UnityEngine;

public class Hover : SingleTone<Hover> 
{
	#region variables
	public float movementSpeed = 1.0f;
	public LayerMask movementLayer = -1;
	public GameObject[] gizmos;

	private float actualDistance;
	private Vector3 targetPosition;
	private SpriteRenderer spriteRenderer;
	#endregion

	#region Folow goods prefab cursor when press button in shop panel
	void Start () 
	{
			this.spriteRenderer = GetComponent<SpriteRenderer> ();

			Vector3 toObjectVector = transform.position - Camera.main.transform.position;
			Vector3 linearDistanceVector = Vector3.Project(toObjectVector,Camera.main.transform.forward);
			actualDistance = linearDistanceVector.magnitude;
	}
	
	void Update () 
	{
		if (spriteRenderer != null) 
		{
			RaycastHit hit;

			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity, movementLayer)) 
			{
				targetPosition = hit.point;
			}
	
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = actualDistance;
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, movementSpeed * Time.deltaTime);
		}
	}
	#endregion

	#region Actuvate and Deactivate goods in shop
	public void Activate()
	{
		if (GameManager.Instance.ClickedButton.GoodPrefab.name == "PlantPot") 
		{
			gizmos [0].SetActive (true);
			gizmos [1].SetActive (false);
			gizmos [2].SetActive (false);
		}

		if (GameManager.Instance.ClickedButton.GoodPrefab.name == "Tree1") 
		{
			gizmos [1].SetActive (true);
			gizmos [0].SetActive (false);
			gizmos [2].SetActive (false);
		}
		
		if (GameManager.Instance.ClickedButton.GoodPrefab.name == "Tree2")
		{
			gizmos [2].SetActive (true);
			gizmos [0].SetActive (false);
			gizmos [1].SetActive (false);
		}
	}

	public void Deactivate()
	{
		gizmos [0].SetActive (false);
		gizmos [1].SetActive (false);
		gizmos [2].SetActive (false);
	}
	#endregion
}
