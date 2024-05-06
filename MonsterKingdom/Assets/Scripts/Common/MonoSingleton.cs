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
                if (_instance == null)
                {
                    _instance = new GameObject($"[{typeof(T).Name}]").AddComponent<T>();
                }

                return _instance;
            }
        }

        protected virtual void Init()
        {
            
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Init();
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}