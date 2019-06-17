using UnityEngine;

public class GlobalAchievement : MonoBehaviour {

    public static GameObject achMenu;
    private void Awake()
    {
        achMenu = this.gameObject;
    }
}