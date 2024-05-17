using System;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDeployWidget : MonoBehaviour
{
    private string _monsterId;
    
    [SerializeField]
    private Button _deployButton;
    
    [SerializeField]
    private MonsterCardWidget _monsterCardWidget;
    
    public void Init(string monsterId,Action callback = null)
    {
        gameObject.SetActive(true);
        _deployButton.onClick.RemoveAllListeners();
        _deployButton.onClick.AddListener(() =>
        {
            callback?.Invoke();
        });
        _monsterId = monsterId;
        if (string.IsNullOrWhiteSpace(monsterId))
        { 
            _monsterCardWidget.gameObject.SetActive(false);
        }
        else
        {
            _monsterCardWidget.gameObject.SetActive(true);
            _monsterCardWidget.MonsterId = _monsterId;
        }
    }
}
