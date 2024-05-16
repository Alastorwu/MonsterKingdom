using Game.Common;

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


    public void Init()
    {
        //UIManager.instance.ShowPanel("CardSettingPanel");
    }

}
