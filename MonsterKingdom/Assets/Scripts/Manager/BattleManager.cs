using cfg;
using cfg.game;
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
            //Debug.Log($"Round: {_round}");
        }
    }

    
    private void Start()
    {
        round = 0;
        /*Main.instance.cfgTables.TblMonster.DataList.ForEach(data =>
        {
            Debug.Log(data.Name);
        });*/
        foreach (Skill skill in Main.instance.cfgTables.TblSkill.DataList)
        {
            Debug.Log(skill.Name);
        }
        /*Main.instance.cfgTables.TbDefineFromExcel2.DataList.ForEach(data =>
        {
            Debug.Log(data.Id);
        });*/
    }
}
