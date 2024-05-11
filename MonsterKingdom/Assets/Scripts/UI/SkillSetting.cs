using System;
using cfg;
using Game.Common;
using UnityEngine;

public class SkillSetting : UIPanelBase
{
    [SerializeField]
    private GameObject _monsterCardOrigin;
    private void Awake()
    {
        foreach (MonsterCfg monsterCfg in LubanCfg.instance.cfgTables.TblMonster.DataList)
        {
            MonsterCardWidget monsterCardWidget 
                = Instantiate(_monsterCardOrigin, transform).GetComponent<MonsterCardWidget>();
            monsterCardWidget.MonsterId = monsterCfg.Id;
        }
    }
}
