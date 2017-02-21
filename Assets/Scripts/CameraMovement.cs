using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	[SerializeField]
	private float speedMovePos =1;

	void Update () {
		var horizontal = -Input.GetAxis ("Mouse X");
		var vertical = -Input.GetAxis ("Mouse Y");
		if (Input.GetKey (KeyCode.Mouse0))
		{
			transform.Translate (horizontal * speedMovePos,0 ,vertical * speedMovePos);
			transform.position = new Vector3 (ClampPos (transform.position.x, -18, 5),transform.position.y,
				ClampPos (transform.position.z, -18, 5));

		}
	}

	public static float ClampPos (float pos, float min, float max)
	{
		if (pos < -30)
			pos = min;
		if (pos > 30)
			pos = max;
		return Mathf.Clamp (pos, min, max);
	}
}