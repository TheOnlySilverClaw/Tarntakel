using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUi : MonoBehaviour
{
    [SerializeField]
    private float _value;

    [SerializeField]
    private RectTransform _handle;
    [SerializeField]
    private Image _sliderImage;

    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = Mathf.Clamp(value, 0f, 1f);
            UpdateSlider();
        }
    }

    private void UpdateSlider()
    {
        _sliderImage.color = Color.HSVToRGB(_value, 1f, 1f);
        _handle.rotation = Quaternion.Euler(0f, 0f, _value * 360f);
    }
}
