using System;
using System.Linq;
using cfg;
using cfg.game;
using TMPro;
using UnityEngine;

public class SkillCardWidget : MonoBehaviour
{
    [SerializeField] 
    private string _skillId;

    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _consume;
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
    
    private void Awake()
    {
#if UNITY_EDITOR
        LubanCfg.instance.Init();
#endif
        Init();
    }

    public void Init()
    {
        if (string.IsNullOrWhiteSpace(_skillId)) return;
        SkillCfg skillCfg = LubanCfg.instance.cfgTables.TblSkill?.GetOrDefault(_skillId);
        if (skillCfg == null) return;
        _name.text = skillCfg.Name;
        string consumeString = "";
        if (skillCfg.PointType != SkillConsumePointType.none)
        {
            consumeString += skillCfg.PointType switch
            {
                SkillConsumePointType.point => "点数",
                SkillConsumePointType.kindPoint => "相同点数",
                SkillConsumePointType.straight => "顺子",
                _ => ""
            };
            consumeString += " " + skillCfg.PointConsume;
        }

        if (skillCfg.MagicConsume.Count > 0)
        {
            consumeString += " " + string.Join(" ", skillCfg.MagicConsume);
        }
        _consume.text = consumeString;
        _desc.text = string.Format(skillCfg.Description, skillCfg.DescriptionVal.Cast<object>().ToArray());
    }
}
