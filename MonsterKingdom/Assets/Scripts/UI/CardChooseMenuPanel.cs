using System;
using Game.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class CardChooseMenuPanel : UIPanelBase
    {
        public static void Open()
        {
            // UIManager.instance.ShowPanel("ChooseMeumPanel");
            UIManager.instance.ShowPanel<CardChooseMenuPanel>();
        }

        public void HidePanel()
        {
            UIManager.instance.HidePanel<CardChooseMenuPanel>();
        }

        [SerializeField]
        private Button _itemBtnOri;
        
        [SerializeField]
        private LayoutGroup _menu;
        
        public override void OnShow()
        {
            if (UiData is not CardChooseMenuData data)
            {
                return;
            }

            var menuTransform = _menu.transform;
            menuTransform.DestroyChildren();
            _menu.GetComponent<RectTransform>().MousePosToUI(data.pos);
            /*for (var i = 0; i < menuTransform.childCount; i++)
            {
                Button button = GameObject.Instantiate(_itemBtnOri, menuTransform.GetChild(i));
                button.gameObject.SetActive(true);
            }*/
            Button changeBtn = GameObject.Instantiate(_itemBtnOri, menuTransform);
            changeBtn.onClick.AddListener(Change);
            var textMeshProUGUI = changeBtn.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshProUGUI != null) textMeshProUGUI.text = "替换";
            changeBtn.gameObject.SetActive(true);
            
            _itemBtnOri.gameObject.SetActive(false);
        }

        private void Change()
        {
            throw new NotImplementedException();
        }
    }
}