using UnityEngine;

public class Nebula : MonoBehaviour {

    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}