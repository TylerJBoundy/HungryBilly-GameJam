using UnityEngine;

[System.Serializable]
public class Player_Move : Character_Move
{

    public Player_Move(float speed, Rigidbody2D rigidbody, SpriteRenderer spriteRenderer) : base(rigidbody, spriteRenderer, speed) { }

}
