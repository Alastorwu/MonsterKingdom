using System.IO;
using cfg;
using Game.Common;
using Luban;
using UnityEngine;

public class Main : MonoSingleton<Main>
{
    public Tables cfgTables;
    
    protected override void Init()
    {
        cfgTables = new cfg.Tables(LoadByteBuf);
        Debug.Log("Tables loaded");
    }

    private static ByteBuf LoadByteBuf(string file)
    {
        return new ByteBuf(File.ReadAllBytes($"{Application.streamingAssetsPath}/GenerateDatas/bytes/{file}.bytes"));
    }
}
