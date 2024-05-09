using System.Collections;
using System.Collections.Generic;
using cfg;
using TMPro;
using UnityEngine;

public class MonsterCardWidget : MonoBehaviour
{
    [SerializeField]
    private string _monsterId;
    
    [SerializeField]
    private TextMeshProUGUI _name;
    
    public string MonsterId
    {
        get => _monsterId;
        set
        {
            _monsterId = value;
            Init();
        }
    }
    
    private void Awake()
    {
#if UNITY_EDITOR
        LubanCfg.instance.Init();
#endif
        Init();
    }

    public void Init()
    {
        if (string.IsNullOrWhiteSpace(_monsterId)) return;
        MonsterCfg monsterCfg = LubanCfg.instance.cfgTables.TblMonster?.GetOrDefault(_monsterId);
        if (monsterCfg == null) return;
        _name.text = monsterCfg.Name;
    }
}
