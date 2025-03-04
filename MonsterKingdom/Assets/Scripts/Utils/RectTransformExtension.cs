using UnityEngine;

namespace Utils
{
    public static class RectTransformExtension
    {
        public static void MousePosToUI(this RectTransform tran,Vector2 pos)
        {
            Debug.Log("screen w:" + Screen.width + ", h:" + Screen.height);
            Debug.Log("click pos x:" + pos.x + ",pos y:" + pos.y);

            float X = Input.mousePosition.x - Screen.width / 2f;
            float Y = Input.mousePosition.y - Screen.height / 2f;
            Vector2 tranPos = new Vector2(X, Y);
            tran.localPosition = tranPos;

            //得到画布的尺寸
            Vector2 uisize = tran.sizeDelta;
            Debug.Log("sizeDelta w:" + uisize.x + ", h:" + uisize.y);

            Vector2 finalPos = new Vector2(X * (uisize.x / Screen.width), Y * (uisize.y / Screen.height));
            tran.localPosition = finalPos;
        }
    }
}