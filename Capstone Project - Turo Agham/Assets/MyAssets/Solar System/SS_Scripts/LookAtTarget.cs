using UnityEngine;

public class LookAtTarget : MonoBehaviour {

    public Transform cameraAR;
    public Transform[] planetDisc;

    private void Update()
    {
        foreach (var item in planetDisc)
        {
            LookAtTargetX(item);
        }
    }

    public void LookAtTargetX(Transform item)
    {
        Vector3 targetPosition = new Vector3(cameraAR.transform.position.x, item.transform.position.y, cameraAR.transform.position.z);
        item.transform.LookAt(targetPosition);
    }

    public void StopLookAt()
    {
        transform.LookAt(null);
    }
}