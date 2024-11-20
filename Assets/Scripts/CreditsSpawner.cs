using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _crabPrefab;
    [SerializeField]
    private float _timeBetweenCrabs = 1f;

    private string[] _nameArray =
    {
        "Katrin Huber",
        "Joel Lacour",
        "Christopher Putz",
        "Jakob Utters",
        "Alexander Keinprecht"
    };

    public void RollCredits()
    {
        StartCoroutine(SpawnCrabs());
    }

    private IEnumerator SpawnCrabs()
    {
        for (int i = 0; i < _nameArray.Length; i++)
        {
            Instantiate(_crabPrefab, transform.position, Quaternion.identity)
                .GetComponent<CreditCrab>()
                .SetName(_nameArray[i])
                .GetComponent<MoveTo>()
                .StartMoving();
            yield return new WaitForSeconds(_timeBetweenCrabs);
        }
    }
}
