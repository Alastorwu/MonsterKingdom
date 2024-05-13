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
    }
}
