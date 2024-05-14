using cfg.game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagicAttributeWidget : MonoBehaviour
{
    [SerializeField] 
    private MagicAttribute _magicAttribute;

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
        /*foreach (var magic in skillCfg.MagicConsume)
        {
            GameObject magicAttr = Instantiate(magicAttrOrigin.gameObject, _magicAttributeLayoutGroup.transform);
            magicAttr.SetActive(true);
            TextMeshProUGUI magicText = magicAttr.GetComponentInChildren<TextMeshProUGUI>();
            
        }*/
    }
}
