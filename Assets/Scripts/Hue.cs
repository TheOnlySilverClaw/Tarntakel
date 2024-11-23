using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hue : MonoBehaviour
{
    [SerializeField]
    private float _hue;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private float _hueOffset;

    public float Value
    {
        get
        {
            float value = _hue + _hueOffset;
            if (value > 1f)
            {
                value -= 1f;
            }
            if (value < 0f)
            {
                value += 1f;
            }
            return value;
        }
    }

    void Start()
    {
        Color.RGBToHSV(_spriteRenderer.color, out _hueOffset, out _, out _);
    }
}
