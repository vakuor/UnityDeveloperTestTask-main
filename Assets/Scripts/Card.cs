using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UIElements/Card")]
public class Card : ScriptableObject
{

    public string Name;
    public bool Disabled;

    [Header("Scene")] 
    public string SceneName;
    
    [Header("UI")]
    public Sprite Background;
    public Sprite GalaxyImage;
    public Sprite MainImage;
    public Sprite DisableImage;

    public ProgressData ProgressData;

    private void OnValidate()
    {
        Name = name;
    }

    public static List<Card> GetAllInstances()
    {
        return Resources.LoadAll<Card>("").ToList();
    }
}