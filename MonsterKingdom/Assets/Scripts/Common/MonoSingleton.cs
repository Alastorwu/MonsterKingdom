using UnityEngine;


namespace Game.Common
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<T>();
                if (_instance == null)
                    _instance = new GameObject($"[{typeof(T).Name}]").AddComponent<T>();

                return _instance;
            }
        }

        /*private void Awake()
        {
            if (_instance == null) _instance = FindObjectOfType<T>();
        }*/

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}