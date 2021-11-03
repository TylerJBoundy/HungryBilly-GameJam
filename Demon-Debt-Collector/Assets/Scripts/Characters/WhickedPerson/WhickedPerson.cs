public class WhickedPerson : Enemy
{
    public override void Dead()
    {
        gm.PersonHealed(reward);
        base.Dead();
    }
}
