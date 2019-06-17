using UnityEngine;

public class DontDistory : MonoBehaviour
{
	public static DontDistory thisGameObjectInstance;

	void Awake()
	{
		if (thisGameObjectInstance == null)
		{
            thisGameObjectInstance = this;
			DontDestroyOnLoad(thisGameObjectInstance);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}