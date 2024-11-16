using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class HueShift : MonoBehaviour
{
    [SerializeField]
    private float _hueShiftSpeed = 0.01f;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public UnityEvent<float> OnUpdate;

    private float _currentHueIntent;
    private float _currentHue;

    // Start is called before the first frame update
    void Start()
    {
        Color.RGBToHSV(_spriteRenderer.color, out _currentHue, out float _s, out float _v);
        OnUpdate?.Invoke(_currentHue);
    }

    // Update is called once per frame
    void Update()
    {
        _currentHue += _currentHueIntent * _hueShiftSpeed;
        if (_currentHue > 1f)
        {
            _currentHue -= 1f;
        }
        if (_currentHue < 0f)
        {
            _currentHue += 1f;
        }
        OnUpdate?.Invoke(_currentHue);
        _spriteRenderer.color = Color.HSVToRGB(_currentHue, 1f, 1f);
    }

    public void ShiftHue(CallbackContext context)
    {
        _currentHueIntent = context.ReadValue<float>();
    }
}
