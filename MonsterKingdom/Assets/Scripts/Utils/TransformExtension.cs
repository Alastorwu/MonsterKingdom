using UnityEngine;

namespace Utils
{
    public static class TransformExtension
    {
        public static void DestroyChildren(this Transform tran)
        {
            for (var index = 0; index < tran.childCount; ++index)
            {
                Object.Destroy(tran.GetChild(index).gameObject);
            }
        }

        public static void DestroyChildrenWithout(this Transform tran, GameObject filter)
        {
            for (var index = 0; index < tran.childCount; ++index)
            {
                var child = tran.GetChild(index).gameObject;

                if (child == filter)
                {
                    continue;
                }

                Object.Destroy(child);
            }
        }

        public static void DestroyChildrenImmediate(this Transform tran)
        {
            for (var index = 0; index < tran.childCount;)
            {
                Object.DestroyImmediate(tran.GetChild(index).gameObject);
            }
        }
        
        /// <summary>
        /// 直接获取子节点GameObject
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static GameObject GetChildObject(this Transform tran, int index)
        {
            var child = tran.GetChild(index);
            return child == null ? null : child.gameObject;
        }
    }
}