using Game.Common;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Awake()
        {
            LubanCfg.instance.Init();
        }
    }
}