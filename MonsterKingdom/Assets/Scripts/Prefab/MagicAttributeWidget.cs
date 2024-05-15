using cfg.game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagicAttributeWidget : MonoBehaviour
{
    [SerializeField] 
    private MagicAttribute _magicAttribute = MagicAttribute.none;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField] 
    private Image _knob;
    public MagicAttribute MagicAttribute
    {
        get => _magicAttribute;
        set
        {
            _magicAttribute = value;
            Init();
        }
    }
    
    public void Init()
    {
        switch (_magicAttribute)
        {
            
            case MagicAttribute.none:
                _text.text = "无";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.gray;
                break;
            case MagicAttribute.fire:
                _text.text = "火";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.red;
                break;
            case MagicAttribute.water:
                _text.text = "水";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.cyan;
                break;
            case MagicAttribute.earth:
                _text.text = "土";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.8f, 0.6f, 0.4f);
                break;
            case MagicAttribute.wind:
                _text.text = "风";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.2f, 0.6f, 0.4f);
                break;
            case MagicAttribute.thunder:
                _text.text = "雷";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.6f);
                break;
            case MagicAttribute.ice:
                _text.text = "冰";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.white;
                break;
            case MagicAttribute.light:
                _text.text = "光";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.yellow;
                break;
            case MagicAttribute.dark:
                _text.text = "暗";
                _text.color = Color.white;
                _knob.GetComponent<Image>().color = Color.black;
                break;
            case MagicAttribute.grass:
                _text.text = "草";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.green;
                break;
            case MagicAttribute.wood:
                _text.text = "木";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.6f, 0.4f, 0.2f);
                break;
            case MagicAttribute.steam:
                _text.text = "蒸汽";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
                break;
            case MagicAttribute.rock:
                _text.text = "岩石";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
                break;
            case MagicAttribute.crystal:
                _text.text = "水晶";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.8f, 0.8f, 1f);
                break;
            case MagicAttribute.lava:
                _text.text = "熔岩";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.8f, 0.4f, 0.2f);
                break;
            case MagicAttribute.steel:
                _text.text = "钢";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f);
                break;
            case MagicAttribute.flame:
                _text.text = "烈焰";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(1f, 0.6f, 0.2f);
                break;
            case MagicAttribute.explosion:
                _text.text = "爆炸";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.8f, 0.2f, 0.2f);
                break;
            case MagicAttribute.iceCrystal:
                _text.text = "冰晶";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.6f, 0.8f, 1f);
                break;
            case MagicAttribute.poison:
                _text.text = "毒";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.6f, 0.2f, 0.6f);
                break;
            case MagicAttribute.life:
                _text.text = "生命";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = new Color(0.2f, 0.8f, 0.2f);
                break;
            default:
                _text.text = "未知";
                _text.color = Color.black;
                _knob.GetComponent<Image>().color = Color.magenta;
                break;
        }
    }
}
