using UnityEngine;
using System;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance;

	/// <summary>
	/// Returns the instance of this singleton.
	/// </summary>
	/// <value>The instance.</value>
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (T) FindObjectOfType(typeof(T));

				if (instance == null)
				{
					GameObject g = new GameObject();
					g.name = typeof(T).Name;
					g.AddComponent<T>();

					instance = g.GetComponent<T>();

					if (Instance == null)
						Debug.LogError("Something is severely wrong when trying to use " + typeof(T) + 
							" as a singleton. Please check the class for what might be wrong.");
				}
			}

			return instance;
		}
	}

	public bool Persist = false;

	protected virtual void Awake ()
	{
		instance = this.GetComponent<T>();

		if (Persist)
			DontDestroyOnLoad(this);
	}

}
