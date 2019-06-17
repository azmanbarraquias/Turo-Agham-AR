using UnityEngine;

public class AnimalCardUnlockTracker_Learn : MonoBehaviour
{
    public bool[] animals;
    public string[] animalTargertName;

    public void AnimalUnlocked(string _animalName)
    {
        int i = 0;
        foreach (var animalT in animalTargertName)
        {
            if (_animalName == animalT)
            {
                animals[i] = true;
                Debug.Log(animalT + " is " + animals[i]);
            }
            i++;
        }

        //for (int i = 0; i < animalTargertName.Length; i++)
        //{
        //    if (_animalName == animalTargertName[i])
        //    {
        //        animals[i] = true;
        //        Debug.Log(_animalName + " is " + animals[i]);
        //    }
        //}

        if (IsAllMissionComplete() == true)
        {
            AchievementManager.Instance.UnlockAchievement("Magnifier");
        }
    }

    private bool IsAllMissionComplete()
    {
        for (int i = 0; i < animals.Length; ++i)
        {
            if (animals[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
