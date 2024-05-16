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
        _monsterId = monsterId;
        if (string.IsNullOrWhiteSpace(monsterId))
        { 
            _monsterCardWidget.gameObject.SetActive(false);
            _deployButton.gameObject.SetActive(true);
            _deployButton.onClick.AddListener(() =>
            {
                callback?.Invoke();
            });
        }
        else
        {
            _monsterCardWidget.gameObject.SetActive(true);
            _monsterCardWidget.MonsterId = _monsterId;
            _deployButton.gameObject.SetActive(false);
        }
    }
}
