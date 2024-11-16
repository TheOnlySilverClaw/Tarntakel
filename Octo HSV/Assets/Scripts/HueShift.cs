using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class HueShift : MonoBehaviour
{
    [SerializeField]
    private float _hueShiftSpeed = 0.01f;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Collider2D _collider;

    public UnityEvent<float> OnUpdate;

    private float _currentHueIntent;
    [SerializeField]
    private float _currentHue;

    [SerializeField]
    private AnimationCurve _visibility;
    [SerializeField]
    private FloatAttribute _deviation;

    private Hue _currentHidingSpot = null;

    // Start is called before the first frame update
    void Start()
    {
        Color.RGBToHSV(_spriteRenderer.color, out _currentHue, out float _s, out float _v);
        OnUpdate?.Invoke(_currentHue);
        _deviation.Value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHue();
    }

    private void FixedUpdate()
    {
        // Find all colliders
        ContactFilter2D filter = new ContactFilter2D();
        filter = filter.NoFilter();
        List<Collider2D> colliders = new List<Collider2D>();
        int collisions = _collider.OverlapCollider(filter, colliders);
        if (collisions == 0)
        {
            _currentHidingSpot = null;
            return;
        }

        // Take the first one as hiding spot
        foreach(Collider2D collider in colliders)
        {
            Hue hue = collider.GetComponent<Hue>();
            if(hue == null)
            {
                continue;
            }
            _currentHidingSpot = hue;
            return;
        }
    }

    private void UpdateHue()
    {
        _currentHue += _currentHueIntent * _hueShiftSpeed * Time.deltaTime;
        if (_currentHue > 1f)
        {
            _currentHue -= 1f;
        }
        if (_currentHue < 0f)
        {
            _currentHue += 1f;
        }
        OnUpdate?.Invoke(_currentHue);
        float alpha = 1f;
        if(_currentHidingSpot != null)
        {
            float value = Mathf.Abs(_currentHidingSpot.Value - _currentHue);
            float valuePlusOne = Mathf.Abs(_currentHidingSpot.Value - _currentHue + 1f);
            // deviation is from 0 to 0.5, so to normalize it we multply by two
            float deviation = Mathf.Min(value, valuePlusOne) * 2;
            _deviation.Value = deviation;
            alpha = _visibility.Evaluate(deviation);
        }
        else
        {
            _deviation.Value = 1f;
        }
        _spriteRenderer.color = Color.HSVToRGB(_currentHue, 1f, 1f).WithAlpha(alpha);
    }

    public void ShiftHue(CallbackContext context)
    {
        _currentHueIntent = context.ReadValue<float>();
    }
}
