using UnityEngine;

namespace Utils
{
    public static class RectTransformExtension
    {
        public static void MousePosToUI(this RectTransform tran,Vector2 pos)
        {
            // 获取Canvas和父RectTransform
            Canvas canvas = tran.GetComponentInParent<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("目标UI不在Canvas中！");
                return;
            }

            RectTransform parentRT = tran.parent as RectTransform;
            if (parentRT == null)
            {
                Debug.LogError("目标UI的父对象缺少RectTransform组件！");
                return;
            }

            // 根据Canvas渲染模式选择相机
            Camera renderCamera = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera;

            // 转换鼠标坐标
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    parentRT, 
                    pos, 
                    renderCamera, 
                    out Vector2 localPoint))
            {
                tran.anchoredPosition = localPoint; // 移动UI
            }
        }
    }
}