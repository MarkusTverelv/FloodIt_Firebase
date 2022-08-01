using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValueToText : MonoBehaviour
{
    float value;
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetTextWithValue(TextMeshProUGUI text)
    {
        value = slider.value;
        text.text = value.ToString();
    }

    public int GetValue(string name)
    {
        if (name == slider.name)
            return (int)value;

        return 0;
    }
}
