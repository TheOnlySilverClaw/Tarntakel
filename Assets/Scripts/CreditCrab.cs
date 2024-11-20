using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditCrab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public GameObject SetName(string name)
    {
        _text.text = name;
        _text.color = new Color(0.16f, 0.13f, 0.14f);
        return gameObject;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
