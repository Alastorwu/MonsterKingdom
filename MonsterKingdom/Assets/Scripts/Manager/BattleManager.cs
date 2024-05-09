using System.Linq;
using cfg;
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
        foreach (SkillCfg skill in LubanCfg.instance.cfgTables.TblSkill.DataList)
        {
            int[] array = skill.DescriptionVal.ToArray();
            Debug.Log(skill.Id + " " + skill.Name + " " +
                      string.Format(skill.Description, array.Cast<object>().ToArray()));
        }
        /*Main.instance.cfgTables.TbDefineFromExcel2.DataList.ForEach(data =>
        {
            Debug.Log(data.Id);
        });*/
    }
}
