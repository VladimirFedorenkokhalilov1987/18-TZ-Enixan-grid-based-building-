using UnityEngine;
using System.Collections;

public class GameManager : SingleTone<GameManager> 
{
	#region Panel goods logic
	[SerializeField]
	private GameObject shopPaneel;

	public goodsBtn ClickedButton 
	{
		get;
		set;
	}

	private void Update()
	{
		HandleEscape ();
	}

	public void PickGoods(goodsBtn goodsButton)
	{
		this.ClickedButton = goodsButton;
		Hover.Instance.Activate ();
	}

	public void BuyGoods()
	{
		Hover.Instance.Activate ();
		shopPaneel.SetActive (false);
	}

	private void HandleEscape()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Hover.Instance.Deactivate();
			ClickedButton = null;
		}
	}
	#endregion
}
