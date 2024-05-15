using System.Linq;
using cfg;
using cfg.game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCardWidget : MonoBehaviour
{
    [SerializeField]
    private string _monsterId;
    
    [SerializeField]
    private TextMeshProUGUI _name;
    
    [SerializeField]
    private TextMeshProUGUI _hp;
    
    [SerializeField]
    private TextMeshProUGUI _speed;
    
    [SerializeField]
    private VerticalLayoutGroup _magicAttributeLayoutGroup;
    
    [SerializeField]
    private VerticalLayoutGroup _skillLayoutGroup;
    
    public string MonsterId
    {
        get => _monsterId;
        set
        {
            _monsterId = value;
            Init();
        }
    }

    public void Init()
    {
        if (string.IsNullOrWhiteSpace(_monsterId)) return;
        MonsterCfg monsterCfg = LubanCfg.instance.cfgTables.TblMonster?.GetOrDefault(_monsterId);
        if (monsterCfg == null) return;
        _name.text = monsterCfg.Name;
        _hp.text = $"HP {monsterCfg.Hp}";
        _speed.text = $"SPEED {monsterCfg.Speed}";
        Transform magicAttrOrigin = _magicAttributeLayoutGroup.transform.GetChild(0);
        magicAttrOrigin.gameObject.SetActive(false);
        foreach (var magic in monsterCfg.Magic)
        {
            GameObject magicAttr = Instantiate(magicAttrOrigin.gameObject, _magicAttributeLayoutGroup.transform);
            magicAttr.SetActive(true);
            MagicAttributeWidget magicAttributeWidget = magicAttr.GetComponent<MagicAttributeWidget>();
            magicAttributeWidget.MagicAttribute = magic;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(_magicAttributeLayoutGroup.GetComponent<RectTransform>());
        Transform skillOrigin = _skillLayoutGroup.transform.GetChild(0);
        skillOrigin.gameObject.SetActive(false);
        foreach (var skillId in monsterCfg.BornSkills)
        {
            SkillCfg skillCfg = LubanCfg.instance.cfgTables.TblSkill?.GetOrDefault(skillId);
            if (skillCfg == null) continue;
            GameObject skill = Instantiate(skillOrigin.gameObject, _skillLayoutGroup.transform);
            skill.SetActive(true);
            string consumeString = "消耗:";
            switch (skillCfg.PointType)
            {
                case SkillConsumePointType.point:
                    consumeString += $"{skillCfg.PointConsume}点";
                    break;
                case SkillConsumePointType.kind:
                    consumeString += $"{skillCfg.PointConsume}个相同点数";
                    break;
                case SkillConsumePointType.kindSix:
                    consumeString += $"{skillCfg.PointConsume}个6点";
                    break;
                case SkillConsumePointType.straight:
                    consumeString += $"{skillCfg.PointConsume}个顺子";
                    break;
                default:
                    consumeString = "";
                    break;
            }

            TextMeshProUGUI skillText = skill.GetComponentInChildren<TextMeshProUGUI>();
            string skillStr =
                $"{skillCfg.Name}  {consumeString}\n  {string.Format(skillCfg.Description, skillCfg.DescriptionVal.Cast<object>().ToArray())}";
            skillText.text = skillStr;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(_skillLayoutGroup.GetComponent<RectTransform>());
    }
}
