/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

// We want to using this Dialogue class as and object to pass on to the DialogueManager

// The Serializable attribute lets you embed a class with sub properties in the inspector.
[System.Serializable]
public class AnimalInfo
{
    #region Variables
    [Header("Information")]
    public string name; //NPC Name

    public string animalType;

    [TextArea(3, 10)] // Attribute to make a string be edited with a height-flexible and scrollable text area.
    public string descriptions;

    [TextArea(3, 10)]
    public string whatDoTheyEat;

    [Space]
    public bool herbivore, carnivore, omnivore;

    [TextArea(3, 10)]
    public string[] facts;
    [Space]
    [Header("Habitat Background")]
    public bool desert;
    public bool hills;
    public bool mountain;
    public bool plains;
    public bool plateus;
    public bool snowland;
    public bool ocean;
    public bool defaultBG;

    #endregion
}
