using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "OptionsInformation ")]
public class OptionsInformation : ScriptableObject
{
    //public int SlideValue;
    public float gameTime;
    public float SpawnTime;
    public void OnEnable()
    {
        gameTime = 60;
    }
    
}
