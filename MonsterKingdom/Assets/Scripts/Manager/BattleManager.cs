using Game.Common;
using UnityEngine;

public class BattleManager : MonoSingleton<BattleManager>
{
    private int _round = 0;
    public int round
    {
        get => _round;
        set
        {
            _round = value;
            Debug.Log($"Round: {_round}");
        }
    }

#if UNITY_EDITOR
    private void Awake()
    {
        var main = Main.instance;
    }
#endif
    
    private void Start()
    {
        round = 0;
        /*Main.instance.cfgTables.TbDefineFromExcel2.DataList.ForEach(data =>
        {
            Debug.Log(data.Id);
        });*/
    }
}
