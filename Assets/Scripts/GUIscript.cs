using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIscript : MonoBehaviour 
{
	#region Timer bar
	[SerializeField]
	private Slider slider;

	[SerializeField]
	private Text timerText;

	private float timer;

	void Start () 
	{
		timer = Time.time;
	}

	void Update () 
	{
		if (timer < Time.time) 
		{
			slider.value -= .033f;
		}
		if (slider.value <= 0)
			slider.value = 60;

		timerText.text = slider.value.ToString ("F1");
	}
	#endregion
}
