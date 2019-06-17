using UnityEngine;

public class ScaleObject : MonoBehaviour
{
	public Transform[] toScale;
	public float scaleSpeed = 0.5f;
	public float Min = 1, Max = 7;
	float i = 1;
	
	public void ScaleAdd()
	{
		if (!(i >= Max))
		{
			foreach (Transform gameObject in toScale)
			{
				gameObject.transform.localScale = new Vector3(
                                                    ((gameObject.transform.localScale.x) + scaleSpeed),
													((gameObject.transform.localScale.y) + scaleSpeed),
													((gameObject.transform.localScale.z) + scaleSpeed)
                                                                                );
			}                   
			i += 0.5f;
		}
	}

	public void ScaleSub()
	{
		if (!(i <= Min))
		{
			foreach (Transform gameObject in toScale)
			{
				gameObject.transform.localScale = new Vector3(
                                                    ((gameObject.transform.localScale.x) - scaleSpeed),
													((gameObject.transform.localScale.y) - scaleSpeed),
													((gameObject.transform.localScale.z) - scaleSpeed)
                                                            );

			}
			i-= 0.5f;
		}
	}
}