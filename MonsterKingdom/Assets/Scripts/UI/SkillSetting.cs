using cfg;
using Game.Common;
using UnityEngine;
using UnityEngine.UI;

public class SkillSetting : UIPanelBase
{
    [SerializeField]
    private GameObject _monsterCardOrigin;
    
    [SerializeField]
    private GameObject _skillCardOrigin;

    [SerializeField]
    private HorizontalLayoutGroup _monsterCardLayoutGroup;
    
    [SerializeField]
    private HorizontalLayoutGroup _skillCardLayoutGroup;
    
    private void Awake()
    {
        foreach (MonsterCfg monsterCfg in LubanCfg.instance.cfgTables.TblMonster.DataList)
        {
            MonsterCardWidget monsterCardWidget 
                = Instantiate(_monsterCardOrigin, _monsterCardLayoutGroup.transform).GetComponent<MonsterCardWidget>();
            monsterCardWidget.MonsterId = monsterCfg.Id;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(_monsterCardLayoutGroup.GetComponent<RectTransform>());

        foreach (var skillCfg in LubanCfg.instance.cfgTables.TblSkill.DataList)
        {
            SkillCardWidget skillCardWidget 
                = Instantiate(_skillCardOrigin, _skillCardLayoutGroup.transform).GetComponent<SkillCardWidget>();
            skillCardWidget.SkillId = skillCfg.Id;
        }
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(_skillCardLayoutGroup.GetComponent<RectTransform>());
    }
}
