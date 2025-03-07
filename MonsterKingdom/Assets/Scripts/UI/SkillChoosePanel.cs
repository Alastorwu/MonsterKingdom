using cfg;
using cfg.game;
using Manager;
using Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillChoosePanel : UIPanelBase
    {
        [SerializeField] private GameObject _skillCardOrigin;
        
        [SerializeField]
        private ScrollRect _skillCardChoose;

        public override void OnShow()
        {
            if (InitData is not SkillChooseData data)
            {
                return;
            }
            Transform content = _skillCardChoose.transform.GetChild(0).GetChild(0);
            for (int i = 0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
            foreach (SkillCfg skillCfg in LubanCfg.instance.cfgTables.TblSkill.DataList)
            {
                if (skillCfg.SkillLearnType != SkillLearnType.learn) continue;

                SkillCardWidget skillCardWidget 
                    = Instantiate(_skillCardOrigin, content).GetComponent<SkillCardWidget>();
                skillCardWidget.SkillId = skillCfg.Id;
                Button skillCardButton = skillCardWidget.AddComponent<Button>();
                skillCardButton.onClick.AddListener(() =>
                {
                    GameManager.instance.teams[0].Monsters[data.monsterIndex].Skills[data.skillIndex] = new Skill
                    {
                        CfgId = skillCfg.Id
                    };
                    data.onMonsterChoose?.Invoke(skillCfg.Id);
                    UIManager.instance.HidePanel<SkillChoosePanel>();
                });
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        }
    }
}