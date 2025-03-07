using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardDeployWidget : MonoBehaviour
{
    private string _skillId;
    private int _monsterIndex;
    private int _skillIndex;
    
    [SerializeField]
    private Image _deployImage;
    
    [SerializeField]
    private SkillCardWidget _skillCardWidget;
    
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallClick);
    }

    private void CallClick()
    {
        UIManager.instance.ShowPanel<SkillChoosePanel>(new SkillChooseData()
        {
            monsterIndex = _monsterIndex,
            skillIndex = _skillIndex,
            onMonsterChoose = OnSkillChoose
        });  
    }
    
    private void OnSkillChoose(string id)
    {
        SetSkillId(id, _monsterIndex,_skillIndex);
    }

    public void SetSkillId(string skillId, int monsterIndex, int skillIndex)
    {
        //gameObject.SetActive(true);
        _skillId = skillId;
        _monsterIndex = monsterIndex;
        _skillIndex = skillIndex;
        if (string.IsNullOrWhiteSpace(skillId))
        { 
            _deployImage.gameObject.SetActive(true);
            _skillCardWidget.gameObject.SetActive(false);
        }
        else
        {
            _deployImage.gameObject.SetActive(false);
            _skillCardWidget.gameObject.SetActive(true);
            _skillCardWidget.SkillId = _skillId;
        }
    }

}
