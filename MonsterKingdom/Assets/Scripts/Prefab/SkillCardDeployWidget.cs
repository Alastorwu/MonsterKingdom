using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardDeployWidget : MonoBehaviour
{
    private string _skillId;
    
    [SerializeField]
    private Image _deployImage;
    
    [SerializeField]
    private SkillCardWidget _skillCardWidget;
    
    public void SetSkillId(string skillId)
    {
        //gameObject.SetActive(true);
        _skillId = skillId;
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
