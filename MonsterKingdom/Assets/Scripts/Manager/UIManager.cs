using System.Collections.Generic;
using Game.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private List<GameObject> _panelList;
    
    [SerializeField]
    private Button _loadingButton;
    
    private Dictionary<string, UIPanelBase> _panelDict = new Dictionary<string, UIPanelBase>();
    
    public Dictionary<string, UIPanelBase> PanelDict => _panelDict;
    
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
        // SceneManager.LoadSceneAsync("BattleScene");
        if (_loadingButton!=null)
        {
            _loadingButton.onClick.RemoveAllListeners();
            _loadingButton.onClick.AddListener(() =>
            {
                SceneManager.LoadSceneAsync("BattleScene").completed += operation =>
                {
                    if (operation.isDone)
                    {
                        _loadingButton.gameObject.SetActive(false);
                        ShowPanel("CardSettingPanel");
                    }
                };
            });
        }
        else
        {
            Debug.LogError("LoadingButton is null");
        }

        
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 确保场景已经加载完毕
        if (mode == LoadSceneMode.Single)
        {
            // 获取新场景的主摄像机
            GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
            if (mainCameraObject != null)
            {
                Camera mainCamera = mainCameraObject.GetComponent<Camera>();
                if (mainCamera != null)
                {
                    // 将Canvas的渲染相机设置为新场景的主摄像机
                    Canvas canvas = GetComponent<Canvas>();
                    canvas.worldCamera = mainCamera;
                }
            }
        }
    }
}
