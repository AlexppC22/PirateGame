using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInfo : MonoBehaviour
{
    public Slider timeslider;
    public OptionsInformation Info;
    public InputField inputField;
    void Update()
    {
        Info.gameTime = timeslider.value;
        if (inputField.text != " " && inputField.text != "")
        {
            Info.SpawnTime = float.Parse(inputField.text);
        }
    }
}
