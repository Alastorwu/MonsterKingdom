using System.Collections.Generic;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MonsterDetailPanel : UIPanelBase
    {
        [SerializeField]
        private TextMeshProUGUI _nameTxt;

        [SerializeField] 
        private Image _monsterImage;
        
        [SerializeField]
        private List<SkillCardDeployWidget> _skills;
        
        private int _monsterIndex;

        public override void OnShow()
        {
            if (InitData is not MonsterDetailData data)
            {
                return;
            }
            _monsterIndex = data.index;
            var monster = GameManager.instance.teams[0].Monsters[_monsterIndex];
            _nameTxt.text = LubanCfg.instance.cfgTables.TblMonster.GetOrDefault(monster.CfgId).Name;
            // _monsterImage.sprite = Resources.Load<Sprite>("Monster/" + monster.CfgId);
            for (var i = 0; i < _skills.Count; i++)
            {
                if (i < monster.Skills.Count)
                {
                    _skills[i].SetSkillId(monster.Skills[i].CfgId);
                }
            }
        }
        
        public void OnClickClose()
        {
            UIManager.instance.HidePanel<MonsterDetailPanel>();
        }
        
    }
}