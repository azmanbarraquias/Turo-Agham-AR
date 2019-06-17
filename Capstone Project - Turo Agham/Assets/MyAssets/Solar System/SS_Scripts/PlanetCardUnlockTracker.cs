using UnityEngine;

public class PlanetCardUnlockTracker : MonoBehaviour {

    public bool[] planets;
    public string[] planetTarger;

    public void planetUnlocked(string _planetName)
    {
        if (_planetName == "Earth")
        {
            AchievementManager.Instance.UnlockAchievement("Astronaut");
        }

        if (_planetName == "SolarSystemTarget")
        {
            AchievementManager.Instance.UnlockAchievement("Space Explorer");
        }

        int i = 0;
        foreach (var planetT in planetTarger)
        {
            if (_planetName == planetT)
            {
                planets[i] = true;
                Debug.Log(planetT + " is " + planets[i]);
            }
            i++;
        }

        if (IsAllMissionComplete() == true)
        {
            AchievementManager.Instance.UnlockAchievement("Planet Card");
        }
    }

    private bool IsAllMissionComplete()
    {
        for (int i = 0; i < planets.Length; ++i)
        {
            if (planets[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
