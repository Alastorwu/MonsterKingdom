using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using DG.Tweening; 

public class DiceWidget : MonoBehaviour
{
    private Button _button;
    private RectTransform _rectTransform;
    
    [SerializeField]
    private TextMeshProUGUI _pointTxt;
    [SerializeField]
    private TextMeshProUGUI _magicAttributeTxt;
    
    public bool isChoose { get; private set; } = false;
    private float _originWidth;
    private float _originHeight;

    private void Awake()
    {
        //获取初始的高度和宽度
        _rectTransform = GetComponent<RectTransform>();
        var rect = _rectTransform.rect;
        _originWidth = rect.width;
        _originHeight = rect.height;
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            isChoose = !isChoose;
            _rectTransform.DOSizeDelta(isChoose
                ? new Vector2(_originWidth * 1.2f, _originHeight * 1.2f)
                : new Vector2(_originWidth, _originHeight), 0.2f);
            _button.image.DOColor(isChoose ? Color.green : Color.white, 0.2f);
        });
    }

    private void Start()
    {
        RandomDice();
    }
    
    private void RandomDice()
    {
        int point = Random.Range(1, 7);
        _pointTxt.text = point.ToString();
    }
}
