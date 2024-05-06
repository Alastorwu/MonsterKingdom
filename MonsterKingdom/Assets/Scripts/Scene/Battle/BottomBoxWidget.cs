using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BottomBoxWidget : MonoBehaviour
{
    [SerializeField]
    private DiceWidget _diceOrigin;
    
    [SerializeField]
    private GameObject _diceBox;
    
    private List<DiceWidget> _diceList = new();

    private void Start()
    {
        // BattleManager.instance.round ++;
        for (int i = 0; i < 10; i++)
        {
            DiceWidget dice = Instantiate(_diceOrigin, _diceBox.transform);
            _diceList.Add(dice);
        }
    }
    

}
