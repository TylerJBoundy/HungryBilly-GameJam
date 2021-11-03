using UnityEngine;

[System.Serializable]
public class Ghost_Move : Character_Move
{

    public Ghost_Move(Rigidbody2D rigidbody, Collider2D collider, SpriteRenderer spriteRenderer) : base(rigidbody, collider, spriteRenderer) { }


    public override void Move(Vector2 movementDirection, bool sprinting = false)
    {
        Vector2 target = new Vector2(movementDirection.x, movementDirection.y);
        Vector2 newPosition = Vector2.MoveTowards(rigidbody.position, target, movementSpeed * Time.deltaTime);
        rigidbody.MovePosition(newPosition);
    }
}
