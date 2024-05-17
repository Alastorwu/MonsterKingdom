using System;
using cfg;
using cfg.game;
using Game.Common;
using Manager;
using Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SkillSetting : UIPanelBase
{
    [SerializeField]
    private GameObject _monsterCardOrigin;
    
    [SerializeField]
    private GameObject _skillCardOrigin;

    [SerializeField]
    private ScrollRect _monsterCardChoose;
    
    [SerializeField]
    private ScrollRect _skillCardChoose;
    
    [SerializeField]
    private MonsterDeployWidget[] _monsterDeployWidgets;
    
    [SerializeField]
    private SkillCardDeployWidget[] _skillCardDeployWidgets;
    
    private void Awake()
    {
        /*foreach (var skillCfg in LubanCfg.instance.cfgTables.TblSkill.DataList)
        {
            SkillCardWidget skillCardWidget 
                = Instantiate(_skillCardOrigin, _skillCardChoose.transform).GetComponent<SkillCardWidget>();
            skillCardWidget.SkillId = skillCfg.Id;
        }
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(_skillCardChoose.GetComponent<RectTransform>());*/
    }
    
    

    private void Start()
    {
        if (GameManager.instance.teams == null) 
            GameManager.instance.teams = new ();
        if (GameManager.instance.teams[0] == null)
        {
            GameManager.instance.teams.Add(new Team
            {
                Monsters = new Monster[3]
            });
        }
        for (var i = 0; i < _monsterDeployWidgets.Length; i++)
        {
            _monsterDeployWidgets[i].SetMonsterId(GameManager.instance.teams?[0]?.Monsters?[i]?.CfgId);
            _monsterDeployWidgets[i].GetComponent<Button>().onClick.AddListener(ShowMonsterCardChoose(i));
        }
        for (var i = 0; i < _skillCardDeployWidgets.Length; i++)
        {
            _skillCardDeployWidgets[i].SetSkillId(GameManager.instance.teams?[0]?.Monsters?[0]?.Skills?[i]?.CfgId);
            _skillCardDeployWidgets[i].GetComponent<Button>().onClick.AddListener(ShowSkillCardChoose(i));
        }
    }

    private UnityAction ShowSkillCardChoose(int index)
    {
        return () => { 
            _skillCardChoose.gameObject.SetActive(true);
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
                    /*GameManager.instance.teams[0].Monsters[0].Skills[index] = new Skill
                    {
                        CfgId = skillCfg.Id
                    };*/
                    _skillCardDeployWidgets[index].SetSkillId(skillCfg.Id);
                    _skillCardChoose.gameObject.SetActive(false);
                    LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
                });
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        };
    }

    private UnityAction ShowMonsterCardChoose(int index)
    {
        return () => { 
            _monsterCardChoose.gameObject.SetActive(true);
            Transform content = _monsterCardChoose.transform.GetChild(0).GetChild(0);
            for (int i = 0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
            foreach (MonsterCfg monsterCfg in LubanCfg.instance.cfgTables.TblMonster.DataList)
            {
                MonsterCardWidget monsterCardWidget 
                    = Instantiate(_monsterCardOrigin, content).GetComponent<MonsterCardWidget>();
                monsterCardWidget.MonsterId = monsterCfg.Id;
                Button monsterCardButton = monsterCardWidget.AddComponent<Button>();
                monsterCardButton.onClick.AddListener(() =>
                {
                    GameManager.instance.teams[0].Monsters[index] = new Monster
                    {
                        CfgId = monsterCfg.Id
                    };
                    _monsterDeployWidgets[index].SetMonsterId(monsterCfg.Id);
                    _monsterCardChoose.gameObject.SetActive(false);
                    LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
                });
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        };
    }
}
