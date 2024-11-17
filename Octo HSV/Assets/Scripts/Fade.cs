using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private float _fadeSpeed;

    public UnityEvent OnFadeDone;

    private void Start()
    {
        if(_image != null)
        {
            Color color = _image.color;
            color.a = 0f;
            _image.color = color;
        }
        else if(_text != null)
        {
            Color color = _text.color;
            color.a = 0f;
            _text.color = color;
        }
    }

    public void StartFade()
    {
        if (_image != null)
        {
            StartCoroutine(FadeInImage());
        }
        else if (_text != null)
        {
            StartCoroutine(FadeInText());
        }
    }

    private IEnumerator FadeInImage()
    {
        for (; _image.color.a <= 0.9f;)
        {
            Color color = _image.color;
            color.a += Time.deltaTime * _fadeSpeed;
            _image.color = color;
            yield return null;
        }
        OnFadeDone?.Invoke();
    }

    private IEnumerator FadeInText()
    {
        for (; _text.color.a <= 0.9f; )
        {
            Color color = _text.color;
            color.a += Time.deltaTime * _fadeSpeed;
            _text.color = color;
            yield return null;
        }
        OnFadeDone?.Invoke();
    }
}
