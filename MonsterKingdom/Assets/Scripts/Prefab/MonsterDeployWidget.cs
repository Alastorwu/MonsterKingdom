using System;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDeployWidget : MonoBehaviour
{
    private string _monsterId;
    
    [SerializeField]
    private Image _deployImage;
    
    [SerializeField]
    private MonsterCardWidget _monsterCardWidget;
    
    public void SetMonsterId(string monsterId)
    {
        //gameObject.SetActive(true);
        _monsterId = monsterId;
        if (string.IsNullOrWhiteSpace(monsterId))
        { 
            _deployImage.gameObject.SetActive(true);
            _monsterCardWidget.gameObject.SetActive(false);
        }
        else
        {
            _deployImage.gameObject.SetActive(false);
            _monsterCardWidget.gameObject.SetActive(true);
            _monsterCardWidget.MonsterId = _monsterId;
        }
    }
}
