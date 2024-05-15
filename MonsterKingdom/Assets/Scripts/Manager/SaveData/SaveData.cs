
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public string name;
    public long saveTime;
    public SaveTroop[] saveTroops; 
    [System.Serializable]
    public struct SaveTroop
    {
        public SaveMonster[] saveMonsters;
    }
    [System.Serializable]
    public struct SaveMonster
    {
        public string cfgId;
        public int[] skillCfgIds;
    }

}


