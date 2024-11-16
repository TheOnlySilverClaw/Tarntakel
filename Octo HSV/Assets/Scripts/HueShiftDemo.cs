using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShiftDemo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private float _hueChangingSpeed = 0.5f;

    private float _currentHue = 0f;

    private void Update()
    {
        _currentHue += _hueChangingSpeed * Time.deltaTime;
        float value = _currentHue;
        if (value > 1f)
        {
            value -= 1f;
        }
        if (value < 0f)
        {
            value += 1f;
        }
        _spriteRenderer.color = Color.HSVToRGB(value, 1f, 1f);
    }
}
