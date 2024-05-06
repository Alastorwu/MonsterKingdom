
namespace Game.Common
{
    public class Singleton<T> where T : new()
    {
        protected static T _instance;

        public static T instance
        {
            get
            {
                _instance ??= new T();
                return _instance;
            }
        }
    }
}
