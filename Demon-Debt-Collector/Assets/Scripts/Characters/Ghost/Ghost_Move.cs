using UnityEngine;

[System.Serializable]
public class Ghost_Move : Character_Move
{

    public Ghost_Move(float speed, Rigidbody2D rigidbody, SpriteRenderer spriteRenderer) : base(rigidbody, spriteRenderer, speed) { }


    public override void Move(Vector2 movementDirection, bool sprinting = false)
    {
        if (!canMove) return;

        //Controls sprite look direction
        if (spriteRenderer != null)
        {
            if (movementDirection.x < 0)
                spriteRenderer.flipX = true;
            else if (movementDirection.x > 0)
                spriteRenderer.flipX = false;
        }

        Vector2 newPosition = Vector2.MoveTowards(rigidbody.position, movementDirection, movementSpeed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPosition);
    }
}
