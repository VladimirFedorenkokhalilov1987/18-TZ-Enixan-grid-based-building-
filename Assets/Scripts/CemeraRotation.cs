using UnityEngine;
using System.Collections;

public class CemeraRotation : MonoBehaviour {
	
	public float sensitivityY = 15F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	Quaternion originalRotation;

	void Update ()
	{
		if (Input.GetAxis("Mouse ScrollWheel")<0)
		{
			// Read the mouse input axis
			rotationY += Input.GetAxis("Mouse ScrollWheel") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
			transform.localRotation = originalRotation  * yQuaternion;
		}
		else if (Input.GetAxis("Mouse ScrollWheel")>0)
		{
			rotationY += Input.GetAxis("Mouse ScrollWheel") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}
	}

	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
}
