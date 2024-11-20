using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnDeath;

    public void Kill()
    {
        OnDeath?.Invoke();
    }
}
