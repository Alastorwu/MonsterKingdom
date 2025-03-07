

[System.Serializable]
public class SaveData
{
    public string name;
    public long saveTime;
    public SaveTeam[] saveTeams; 
    [System.Serializable]
    public struct SaveTeam
    {
        public SaveMonster[] saveMonsters;
    }
    [System.Serializable]
    public struct SaveMonster
    {
        public string cfgId;
        public string[] skillCfgIds;
    }

}


