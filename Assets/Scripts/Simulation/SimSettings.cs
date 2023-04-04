using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SimSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider popCountSlider;
    public Slider salmonMaxSpeedSlider;
    public Slider bearSpeedSlider;
    public Slider bearAggressionSlider;
    public Slider currentResistanceSlider;
    public TMP_Dropdown mapSelection;
    public string[] mapNames = {"Autumn Map", "Spring Map", "Winter Map"};
    void Start()
    {
       // add listeners to sliders; invoke methods when value of slider changes 
       popCountSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(popCountSlider);});
       salmonMaxSpeedSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(salmonMaxSpeedSlider);});
       bearSpeedSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(bearSpeedSlider);});
       bearAggressionSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(bearAggressionSlider);});
       currentResistanceSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(currentResistanceSlider);});
       mapSelection.onValueChanged.AddListener(delegate {ChangeDropdownValue(mapSelection);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSliderValue(Slider slider)
    {
        Debug.Log((int)slider.value);
    }

    public void ChangeDropdownValue(TMP_Dropdown dropdown)
    {
        Debug.Log(mapNames[dropdown.value]);
    }
}
