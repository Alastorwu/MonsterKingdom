using cfg;
using cfg.game;
using Manager;
using Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MonsterChoosePanel : UIPanelBase
    {
        
        [SerializeField]
        private GameObject _monsterCardOrigin;
        
        [SerializeField]
        private ScrollRect _monsterCardChoose;
        
        public override void OnShow()
        {
            if (InitData is not MonsterChooseData data)
            {
                return;
            }
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
                    GameManager.instance.teams[0].Monsters[data.index] = new Monster
                    {
                        CfgId = monsterCfg.Id
                    };
                    data.onMonsterChoose?.Invoke(monsterCfg.Id);
                    _monsterCardChoose.gameObject.SetActive(false);
                    LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
                });
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        }
    }
}