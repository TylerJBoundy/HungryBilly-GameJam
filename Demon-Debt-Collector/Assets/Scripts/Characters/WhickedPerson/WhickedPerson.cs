public class WhickedPerson : Enemy
{
    public override void Dead() //handles further death behaviour for the whicked person character.
    {
        gm.PersonHealed(reward);
        base.Dead();
    }
}
