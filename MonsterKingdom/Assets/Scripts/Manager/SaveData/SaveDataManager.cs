using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Common;
using UnityEngine;

public class SaveDataManager : MonoSingleton<SaveDataManager>
{
    private SaveData[] _saveDatas;
    private int saveMaxCount = 10;
    
    public SaveData[] SaveDatas
    {
        set
        {
            _saveDatas = value;
            Save();
        }
        get => _saveDatas;
    }

    public void Init()
    {
        _saveDatas = new SaveData[saveMaxCount];
        for (int i = 0; i < saveMaxCount; i++)
        {
            LoadSave(i);
        }
        
        Save();
    }

    public void Save()
    {
        if (_saveDatas==null)
        {
            Debug.LogError("SaveData is null");
            return;
        }

        FileStream fs = null;
        try
        {
            for (var i = 0; i < _saveDatas.Length; i++)
            {
                if(_saveDatas[i]==null) continue;
                _saveDatas[i].saveTime = System.DateTimeOffset.Now.ToUnixTimeSeconds();
                BinaryFormatter bf=new BinaryFormatter();
                fs=File.Create(Application.persistentDataPath+$"/SaveData{i}.save");
                bf.Serialize(fs,_saveDatas[i]);
            }
            
        }
        finally
        {
            fs?.Close();
        }
        
    }

    private void LoadSave(int index)
    {
        if (System.IO.File.Exists(Application.persistentDataPath + $"/SaveData{index}.save"))
        {
            FileStream fs = null;
            try
            {
                BinaryFormatter bf=new BinaryFormatter();
                fs=File.Open(Application.persistentDataPath+$"/SaveData{index}.save",FileMode.Open);//打开文件
                _saveDatas[index]=bf.Deserialize(fs) as SaveData;
            }
            finally
            {
                fs?.Close();
            }
        }
        else
        {
            // _saveDatas[index] = new SaveData();
            // _saveData.time = System.DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}
