/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class AnimalDistanceEffect : MonoBehaviour {

	#region Variables
	public GameObject thisModel;
	public GameObject targetModel;
	public Animator[] modelAnimation;
	public AudioSource audioSource;
	public AudioClip modelSoundClip;
	#endregion
 
	void Update()
	{
		float distance = Vector3.Distance(thisModel.transform.position, targetModel.transform.position);

		if (distance > 10)
		{
            StopLookAt();
            audioSource.Stop();
			modelAnimation[0].SetBool("TigerAttack", false);
		}
		if (10 <= distance && distance < 13)
		{
			audioSource.Play();
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 1");
		}
		if (8 <= distance && distance < 10)
		{
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 2");
		}
		if (6 <= distance && distance < 8)
		{
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 3");
		}
		if (4.5 <= distance && distance < 6)
		{
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 4");
		}
		if (3.0 <= distance && distance < 4.5)
		{
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 5");
		}
		if (2.0 < distance && distance < 3.0)
		{
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 6");
		}
		if (2.0 > distance)
		{
			modelAnimation[0].SetBool("TigerAttack", true);
			LookAtTarget();
			//Debug.Log("Level 7");
		}
	}
    public void LookAtTarget()
    {
        Vector3 targetPosition = new Vector3(targetModel.transform.position.x, transform.position.y, targetModel.transform.position.z);
        transform.LookAt(targetPosition);
    }

    public void StopLookAt()
    {
        transform.LookAt(null);
    }
}