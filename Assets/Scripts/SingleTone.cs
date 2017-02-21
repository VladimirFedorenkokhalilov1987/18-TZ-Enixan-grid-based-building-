using UnityEngine;
using System.Collections;

public abstract class SingleTone<T> : MonoBehaviour where T :MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get{ 
			if (instance == null) {
				instance = FindObjectOfType<T> ();
			}
			return instance;
		}
	}
}
