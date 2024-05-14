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
            TextMeshProUGUI magicText = magicAttr.GetComponentInChildren<TextMeshProUGUI>();
            switch (magic)
            {
                
                case MagicAttribute.none:
                    magicText.text = "无";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.gray;
                    break;
                case MagicAttribute.fire:
                    magicText.text = "火";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.red;
                    break;
                case MagicAttribute.water:
                    magicText.text = "水";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.cyan;
                    break;
                case MagicAttribute.earth:
                    magicText.text = "土";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.8f, 0.6f, 0.4f);
                    break;
                case MagicAttribute.wind:
                    magicText.text = "风";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.2f, 0.6f, 0.4f);
                    break;
                case MagicAttribute.thunder:
                    magicText.text = "雷";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.6f);
                    break;
                case MagicAttribute.ice:
                    magicText.text = "冰";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.white;
                    break;
                case MagicAttribute.light:
                    magicText.text = "光";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.yellow;
                    break;
                case MagicAttribute.dark:
                    magicText.text = "暗";
                    magicText.color = Color.white;
                    magicAttr.GetComponent<Image>().color = Color.black;
                    break;
                case MagicAttribute.grass:
                    magicText.text = "草";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.green;
                    break;
                case MagicAttribute.wood:
                    magicText.text = "木";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.6f, 0.4f, 0.2f);
                    break;
                case MagicAttribute.steam:
                    magicText.text = "蒸汽";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
                    break;
                case MagicAttribute.rock:
                    magicText.text = "岩石";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
                    break;
                case MagicAttribute.crystal:
                    magicText.text = "水晶";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.8f, 0.8f, 1f);
                    break;
                case MagicAttribute.lava:
                    magicText.text = "熔岩";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.8f, 0.4f, 0.2f);
                    break;
                case MagicAttribute.steel:
                    magicText.text = "钢";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f);
                    break;
                case MagicAttribute.flame:
                    magicText.text = "烈焰";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(1f, 0.6f, 0.2f);
                    break;
                case MagicAttribute.explosion:
                    magicText.text = "爆炸";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.8f, 0.2f, 0.2f);
                    break;
                case MagicAttribute.iceCrystal:
                    magicText.text = "冰晶";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.6f, 0.8f, 1f);
                    break;
                case MagicAttribute.poison:
                    magicText.text = "毒";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.6f, 0.2f, 0.6f);
                    break;
                case MagicAttribute.life:
                    magicText.text = "生命";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = new Color(0.2f, 0.8f, 0.2f);
                    break;
                default:
                    magicText.text = "未知";
                    magicText.color = Color.black;
                    magicAttr.GetComponent<Image>().color = Color.magenta;
                    break;
            }
            
        }
        _desc.text = string.Format(skillCfg.Description, skillCfg.DescriptionVal.Cast<object>().ToArray());
    }
}
