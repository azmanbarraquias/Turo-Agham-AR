using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroryOnEnable : MonoBehaviour {

    private void OnEnable()
    {
        Destroy(this.gameObject, 5f);
    }

    public void DestoryThis()
    {
        Destroy(this.gameObject);
    }
}
