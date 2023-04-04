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
    public TextMeshProUGUI popCountValueText;
    public TextMeshProUGUI salmonMaxSpeedValueText;
    public TextMeshProUGUI bearSpeedValueText;
    public TextMeshProUGUI bearAggressionValueText;
    public TextMeshProUGUI currentResistanceValueText;
    public string[] mapNames = {"Autumn Map", "Spring Map", "Winter Map"};
    void Start()
    {
       // add listeners to sliders; invoke methods when value of slider changes 
       popCountSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(popCountSlider, popCountValueText);});
       salmonMaxSpeedSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(salmonMaxSpeedSlider, salmonMaxSpeedValueText);});
       bearSpeedSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(bearSpeedSlider, bearSpeedValueText);});
       bearAggressionSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(bearAggressionSlider, bearAggressionValueText);});
       currentResistanceSlider.onValueChanged.AddListener(delegate {ChangeSliderValue(currentResistanceSlider, currentResistanceValueText);});
       mapSelection.onValueChanged.AddListener(delegate {ChangeDropdownValue(mapSelection);});

       // display default slider values...can be modified in Unity Editor
       ChangeSliderValue(popCountSlider, popCountValueText);
       ChangeSliderValue(salmonMaxSpeedSlider, salmonMaxSpeedValueText);
       ChangeSliderValue(bearSpeedSlider, bearSpeedValueText);
       ChangeSliderValue(bearAggressionSlider, bearAggressionValueText);
       ChangeSliderValue(currentResistanceSlider, currentResistanceValueText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSliderValue(Slider slider, TextMeshProUGUI valueText)
    {
        Debug.Log((int)slider.value);
        valueText.text = ((int)slider.value).ToString();
    }

    public void ChangeDropdownValue(TMP_Dropdown dropdown)
    {
        Debug.Log(mapNames[dropdown.value]);
    }
}
