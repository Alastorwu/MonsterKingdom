using System;
using cfg;
using UnityEngine;

public class SkillSetting : MonoBehaviour
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
