using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class SliderValueToText : MonoBehaviour {
  public Slider sliderUI;
  //private Text textSliderValue;
  private TMP_Text textTM;

  void Start (){
    textTM = GetComponent<TMP_Text>();
    ShowSliderValue();
  }

  public void ShowSliderValue () {
    string sliderMessage =  String.Format("{0:0.00}", sliderUI.value);

        textTM.text = sliderMessage;
  }
}
