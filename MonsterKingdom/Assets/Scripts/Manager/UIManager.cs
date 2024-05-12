using System.Collections.Generic;
using Game.Common;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private List<GameObject> _panelList;
    
    private Dictionary<string, UIPanelBase> _panelDict = new Dictionary<string, UIPanelBase>();
    
    public void ShowPanel(string panelName)
    {
        if (_panelDict.ContainsKey(panelName))
        {
            _panelDict[panelName].gameObject.SetActive(true);
        }
        else
        {
            foreach (GameObject panelPrefab in _panelList)
            {
                if (!panelPrefab.TryGetComponent(out UIPanelBase uiPanel)) continue;
                if(uiPanel.name != panelName) continue;
                GameObject panel = Instantiate(panelPrefab,transform);
                RectTransform rectTransform = panel.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;
                
                _panelDict.Add(panelName, panel.GetComponent<UIPanelBase>());
                break;
            }
            
        }
    }
    
    private void Start()
    {
        ShowPanel("CardSettingPanel");
    }
}
