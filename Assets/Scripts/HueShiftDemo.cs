using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShiftDemo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField]
    private float _hueChangingSpeed = 0.5f;

    [SerializeField]
    private float _currentHue = 0f;

    private void Update()
    {
        _currentHue += _hueChangingSpeed * Time.deltaTime;
        if (_currentHue > 1f)
        {
            _currentHue -= 1f;
        }
        if (_currentHue < 0f)
        {
            _currentHue += 1f;
        }
        _spriteRenderer.color = Color.HSVToRGB(_currentHue, 1f, 1f);
    }
}
