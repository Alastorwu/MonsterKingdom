using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDeployWidget : MonoBehaviour
{
    private string _monsterId;
    private int _index;
    
    public string monsterId => _monsterId;
    
    [SerializeField]
    private Image _deployImage;
    
    [SerializeField]
    private MonsterCardWidget _monsterCardWidget;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallClick);
    }

    private void CallClick()
    {
        if (_monsterId != null)
        {
            UIManager.instance.ShowPanel<CardChooseMenuPanel>(new CardChooseMenuData()
            {
                pos = Input.mousePosition,
                index = _index,
                onMonsterChoose = OnMonsterChoose
            });
        }
        else
        {
            UIManager.instance.ShowPanel<MonsterChoosePanel>(new MonsterChooseData()
            {
                index = _index,
                onMonsterChoose = OnMonsterChoose
            });  
        }
    }

    private void OnMonsterChoose(string id)
    {
        SetMonsterId(id, _index);
    }

    public void SetMonsterId(string monsterId, int index)
    {
        //gameObject.SetActive(true);
        _monsterId = monsterId;
        _index = index;
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
