using UnityEngine;

public class ARPlanetDiscriptionLootAtCam : MonoBehaviour
{
    public Transform cameraAR;
    public Transform[] planetDisc;

    private void Update()
    {
        foreach (var item in planetDisc)
        {
            LookAtTarget(item);
        }
    }

    public void LookAtTarget(Transform item)
    {
        Vector3 targetPosition = new Vector3(cameraAR.transform.position.x, item.transform.position.y, cameraAR.transform.position.z);
        item.transform.LookAt(targetPosition);
        item.transform.Rotate(0, 180, 0);
    }

    public void StopLookAt()
    {
        transform.LookAt(null);
    }
}