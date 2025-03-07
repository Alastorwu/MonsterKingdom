using System;
using System.Collections.Generic;
using Game.Common;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    
    [SerializeField]
    private Button _loadingButton;
    
    private Dictionary<string, UIPanelBase> _panelDict = new Dictionary<string, UIPanelBase>();
    
    public Dictionary<string, UIPanelBase> PanelDict => _panelDict;

    private UIPanelsSo panelsSo;

    private void Awake()
    {
        panelsSo = Resources.Load<UIPanelsSo>($"SettingAssets/UIPanel");
    }


    public void ShowPanel(string panelName)
    {
        if (_panelDict.ContainsKey(panelName))
        {
            ShowPanelContainInner(_panelDict[panelName]);
        }
        else
        {
            foreach (UIPanelBase panelPrefab in panelsSo.uIPanels)
            {
                if(panelPrefab.name != panelName) continue;
                ShowPanelNewInner(panelPrefab);
                break;
            }
        }
    }
    
    private void ShowPanelNewInner(UIPanelBase panelPrefab, UIData uiData = null)
    {
        UIPanelBase panel = Instantiate(panelPrefab,transform);
        RectTransform rectTransform = panel.GetComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
                
        _panelDict.Add(panelPrefab.name, panel.GetComponent<UIPanelBase>());
        panel.InitData = uiData;
        panel.Show();
    }
    
    public void ShowPanel<T>(UIData uiData = null) where T : UIPanelBase
    {
        string panelName = typeof(T).Name;
        if (_panelDict.ContainsKey(panelName))
        {
            ShowPanelContainInner(_panelDict[panelName],uiData);
        }
        else
        {
            foreach (UIPanelBase panelPrefab in panelsSo.uIPanels)
            {
                if(panelPrefab is not T) continue;
                ShowPanelNewInner(panelPrefab,uiData);
                break;
            }
        }
    }

    private void ShowPanelContainInner(UIPanelBase uiPanelBase, UIData uiData = null)
    {
        // uiPanelBase.gameObject.SetActive(true);
        uiPanelBase.InitData = uiData;
        uiPanelBase.Show();
        uiPanelBase.OnShow();
    }

    public void HidePanel<T>()
    {
        string panelName = typeof(T).Name;
        if (_panelDict.ContainsKey(panelName))
        {
            _panelDict[panelName].Hide();
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
