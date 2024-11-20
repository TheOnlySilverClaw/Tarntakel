using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUi : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Sprite _coin;

    public void Collect()
    {
        _image.sprite = _coin;
    }
}
