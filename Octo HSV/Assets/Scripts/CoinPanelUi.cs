using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPanelUi : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinUiPrefab;

    private List<CoinUi> _coinUi = new List<CoinUi>();

    public void SpawnEmptyCoin()
    {
        CoinUi coinUi = Instantiate(_coinUiPrefab, transform).GetComponent<CoinUi>();
        _coinUi.Add(coinUi);
    }

    public void CollectCoin(int coin)
    {
        _coinUi[coin].Collect();
    }
}
