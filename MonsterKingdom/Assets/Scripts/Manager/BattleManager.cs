using Game.Common;

public class BattleManager : Singleton<BattleManager>
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

}
