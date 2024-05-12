using cfg;
using Game.Common;
using UnityEngine;
using UnityEngine.UI;

public class SkillSetting : UIPanelBase
{
    [SerializeField]
    private GameObject _monsterCardOrigin;

    [SerializeField]
    private HorizontalLayoutGroup _monsterCardLayoutGroup;
    
    private void Awake()
    {
        foreach (MonsterCfg monsterCfg in LubanCfg.instance.cfgTables.TblMonster.DataList)
        {
            MonsterCardWidget monsterCardWidget 
                = Instantiate(_monsterCardOrigin, _monsterCardLayoutGroup.transform).GetComponent<MonsterCardWidget>();
            monsterCardWidget.MonsterId = monsterCfg.Id;
        }
    }
}
