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
        return gameObject;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
