using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : MonoBehaviour
{
    private static Exit _instance;

    private int _collectables = 0;
    private int _maxCollectables = 0;

    public UnityEvent OnWin;

    public static Exit Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Register()
    {
        _maxCollectables++;
    }

    public void Collect()
    {
        _collectables++;
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement movement = collision.GetComponent<Movement>();
        if (movement != null && _collectables == _maxCollectables)
        {
            OnWin?.Invoke();
        }
    }
}
