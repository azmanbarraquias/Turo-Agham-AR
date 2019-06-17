using UnityEngine;

public class ToggleOnOff : MonoBehaviour {

    public GameObject[] duck;
    [Header("Texture")]
    public Renderer duckTexture;
    public Material Mat1;

    public void ToggleOnOffM()
    {
        duck[0].SetActive(!duck[0].activeSelf);
        duck[1].SetActive(!duck[1].activeSelf);
    }

    public void GetTexture()
    {
        Mat1 = duckTexture.GetComponent<Renderer>().material;
        duckTexture.material = Mat1;
    }
}
