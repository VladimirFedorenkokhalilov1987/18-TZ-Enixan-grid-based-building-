using UnityEngine;
using System.Collections;

public class goodsBtn : MonoBehaviour 
{
	#region Goods prefabs select on the buttons in shop panel
	[SerializeField]
	private GameObject goodPrefab;

	public GameObject GoodPrefab
	{
		get
		{ 
			return goodPrefab;
		}
	}
	#endregion
}
