using Game.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField]
        private Button _startButton;
        
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

        private void Start()
        {
            _startButton?.onClick.AddListener(StartGame);
            
        }

        private void StartGame()
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}