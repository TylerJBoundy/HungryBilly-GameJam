using UnityEngine;

[System.Serializable]
public class Player_Move : Character_Move
{
    private Animator animator;

    public Player_Move(float speed, Rigidbody2D rigidbody, SpriteRenderer spriteRenderer, Animator animator) : base(rigidbody, spriteRenderer, speed) { this.animator = animator; }

    public override void Move(Vector2 movementDirection, bool sprinting = false)
    {
        base.Move(movementDirection, sprinting);

        //animation
        if (canMove && movementDirection != new Vector2(0, 0))
        {
            animator.SetBool("Moving", true);
        } else animator.SetBool("Moving", false);
    }
}
