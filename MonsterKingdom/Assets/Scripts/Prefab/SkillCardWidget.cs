using System;
using System.Linq;
using cfg;
using cfg.game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardWidget : MonoBehaviour
{
    [SerializeField] 
    private string _skillId;

    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _consumeTxt;
    [SerializeField]
    private HorizontalLayoutGroup _magicAttributeLayoutGroup;
    [SerializeField]
    private TextMeshProUGUI _desc;

    public string SkillId
    {
        get => _skillId;
        set
        {
            _skillId = value;
            Init();
        }
    }
    
    public void Init()
    {
        if (string.IsNullOrWhiteSpace(_skillId)) return;
        SkillCfg skillCfg = LubanCfg.instance.cfgTables.TblSkill?.GetOrDefault(_skillId);
        if (skillCfg == null) return;
        _name.text = skillCfg.Name;
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
        }
        _consumeTxt.text = consumeString;
        Transform magicAttrOrigin = _magicAttributeLayoutGroup.transform.GetChild(0);
        magicAttrOrigin.gameObject.SetActive(false);
        foreach (var magic in skillCfg.MagicConsume)
        {
            GameObject magicAttr = Instantiate(magicAttrOrigin.gameObject, _magicAttributeLayoutGroup.transform);
            magicAttr.SetActive(true);
            magicAttr.GetComponent<MagicAttributeWidget>().MagicAttribute = magic;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(_magicAttributeLayoutGroup.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(_consumeTxt.transform.parent.GetComponent<RectTransform>());
        _desc.text = string.Format(skillCfg.Description, skillCfg.DescriptionVal.Cast<object>().ToArray());
    }
}
