using System.Collections.Generic;
using Game.Common;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField]
        private Button _startButton;
        
        public List<Team> teams = new();
        
        
        private void Awake()
        {
            SaveDataManager.instance.Init();
            LubanCfg.instance.Init();
            
            
            SaveDataManager.instance.SaveDatas[0] = new SaveData
            {
                name = "test",
                saveTime = System.DateTimeOffset.Now.ToUnixTimeSeconds(),
                saveTeams = new SaveData.SaveTeam[1]
                {
                    new()
                    {
                        saveMonsters = new SaveData.SaveMonster[3]
                        {
                            new()
                            {
                                cfgId = "1",
                                skillCfgIds = new int[]{1,2,3}
                            },new()
                            {
                                cfgId = "2",
                                skillCfgIds = new int[]{1,2,3}
                            },new()
                            {
                                cfgId = "3",
                                skillCfgIds = new int[]{1,2,3}
                            }
                        }
                    }
                }
                
            };
            SaveDataManager.instance.Save();
            /*for (var i = 0; i < SaveDataManager.instance.SaveDatas.Length; i++)
            {
                if (SaveDataManager.instance.SaveDatas[i] == null) continue;
                Debug.Log(SaveDataManager.instance.SaveDatas[i].name);
            }*/
            if (SaveDataManager.instance.SaveDatas[0] != null)
            {
                foreach (var saveTeam in SaveDataManager.instance.SaveDatas[0].saveTeams)
                {
                    Team team = new Team();
                    for (int i = 0; i < saveTeam.saveMonsters.Length; i++)
                    {
                        team.Monsters[i] = new Monster()
                        {
                            CfgId = saveTeam.saveMonsters[i].cfgId,
                            Skills = { new Skill()
                            {
                                CfgId = saveTeam.saveMonsters[i].skillCfgIds[0].ToString()
                            }}
                        };
                    }
                    teams.Add(team);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    teams.Add(new Team());
                }
            }

            
        }

        private void StartGame()
        {
            _startButton.gameObject.SetActive(false);
            SceneManager.LoadScene("BattleScene");
            BattleManager.instance.Init();
        }
    }
}