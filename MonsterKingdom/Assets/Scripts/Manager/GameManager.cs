using Game.Common;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Awake()
        {
            SaveDataManager.instance.Init();
            /*SaveDataManager.instance.SaveDatas[0] = new SaveData
            {
                name = "test",
                saveTime = System.DateTimeOffset.Now.ToUnixTimeSeconds()
            };
            SaveDataManager.instance.Save();*/
            /*for (var i = 0; i < SaveDataManager.instance.SaveDatas.Length; i++)
            {
                if (SaveDataManager.instance.SaveDatas[i] == null) continue;
                Debug.Log(SaveDataManager.instance.SaveDatas[i].name);
            }*/
            LubanCfg.instance.Init();
        }
    }
}