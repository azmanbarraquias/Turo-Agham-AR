using UnityEngine;

public class MoveX : MonoBehaviour {

	public float speed;
    Vector3 orginalPosition;

    void Start()
    {
        orginalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update () {
		transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MeteorWallReset")
        {
            Debug.Log("XXX");
            transform.position = orginalPosition;
        }
    }
}