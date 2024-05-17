using System;
using cfg;
using Game.Common;
using Manager;
using Model;
using UnityEngine;
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
    private GameObject _monsterCardChoose;
    
    [SerializeField]
    private HorizontalLayoutGroup _skillCardChoose;
    
    [SerializeField]
    private MonsterDeployWidget[] _monsterDeployWidgets;
    
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
        /*foreach (Monster monster in GameManager.instance.teams[0].Monsters)
        {
            if (monster == null) continue;
            if (_monsterDeployWidgets.Length == 0) continue;
            
            MonsterCardWidget monsterCardWidget
                = Instantiate(_monsterCardOrigin, _monsterCardChoosed.transform).GetComponent<MonsterCardWidget>();
            monsterCardWidget.MonsterId = monster.CfgId;
        }*/
        for (var i = 0; i < 3; i++)
        {
            
            if (_monsterDeployWidgets.Length <= i ) continue;
            if(_monsterDeployWidgets[i] == null) continue;
            var index = i;
            /*if (GameManager.instance.teams[0].Monsters[i] == null
                || string.IsNullOrWhiteSpace(GameManager.instance.teams[0].Monsters[i].CfgId))
            {
                _monsterDeployWidgets[i].Init(null, () =>
                {
                    ShowMonsterCardChoose(index);
                });
            }
            else
            {
                _monsterDeployWidgets[i].Init(GameManager.instance.teams[0].Monsters[i].CfgId,
                    () =>
                    {
                        ShowMonsterCardChoose(index);
                    });
            }*/
            _monsterDeployWidgets[i].Init(GameManager.instance.teams[0].Monsters[i].CfgId,
                () =>
                {
                    ShowMonsterCardChoose(index);
                });
        }
    }
    
    private void ShowMonsterCardChoose(int index)
    {
        _monsterCardChoose.gameObject.SetActive(true);
        Transform content = _monsterCardChoose.transform.GetChild(0).GetChild(0).GetChild(0);
        
        foreach (MonsterCfg monsterCfg in LubanCfg.instance.cfgTables.TblMonster.DataList)
        {
            MonsterCardWidget monsterCardWidget 
                = Instantiate(_monsterCardOrigin, content).GetComponent<MonsterCardWidget>();
            monsterCardWidget.MonsterId = monsterCfg.Id;
            Button monsterCardButton = monsterCardWidget.GetComponent<Button>();
            monsterCardButton.onClick.AddListener(() =>
            {
                GameManager.instance.teams[0].Monsters[index] = new Monster
                {
                    CfgId = monsterCfg.Id
                };
                _monsterDeployWidgets[index].Init(monsterCfg.Id);
                _monsterCardChoose.gameObject.SetActive(false);
                LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
            
            });
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());

    }
}
