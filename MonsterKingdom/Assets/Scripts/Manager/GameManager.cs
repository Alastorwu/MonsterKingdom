﻿using System.Collections.Generic;
using Game.Common;
using Model;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public List<Team> teams = new();
        
        
        private void Awake()
        {
            SaveDataManager.instance.Init();
            LubanCfg.instance.Init();
            
            
            /*SaveDataManager.instance.SaveDatas[0] = new SaveData
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
            SaveDataManager.instance.Save();*/
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
                            Skills = new []
                            {
                                new Skill(){CfgId = saveTeam.saveMonsters[i].skillCfgIds[0]},
                                new Skill(){CfgId = saveTeam.saveMonsters[i].skillCfgIds[1]},
                                new Skill(){CfgId = saveTeam.saveMonsters[i].skillCfgIds[2]},
                                new Skill(){CfgId = saveTeam.saveMonsters[i].skillCfgIds[3]}
                            }
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

        private void Start()
        {
        }

        private void StartGame()
        {
            // _startButton.gameObject.SetActive(false);
            // SceneManager.LoadSceneAsync("BattleScene");
        }
    }
}