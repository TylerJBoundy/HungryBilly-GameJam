using UnityEngine;

[System.Serializable]
public class Player_Move : Character_Move
{

    public Player_Move(Rigidbody2D rigidbody, Collider2D collider, SpriteRenderer spriteRenderer) : base(rigidbody, collider, spriteRenderer) { }

}
