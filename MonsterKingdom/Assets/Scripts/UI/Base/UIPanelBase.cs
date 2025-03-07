using UnityEngine;

namespace UI
{
    public abstract class UIPanelBase : MonoBehaviour
    {
        public UIData InitData;

        public virtual void Init()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
            gameObject.transform.SetAsLastSibling();
            OnShow();
        }
        
        public virtual void OnShow()
        {
        }
        
        public virtual void Hide()
        {
            OnHide();
            gameObject.SetActive(false);
        }
        
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
        
        protected virtual void OnHide()
        {
        }
    }
}