using UnityEngine;

[System.Serializable]
public abstract class Character_Move
{
    public bool canMove = true;

    [Header("Movement Variables")]
    [SerializeField] public float movementSpeed;
    [SerializeField] protected float PERCENTAGE_INCREASE_WHEN_SPRINTING = 25f;

    protected Rigidbody2D rigidbody;
    protected SpriteRenderer spriteRenderer;

    public Character_Move(Rigidbody2D rigidbody, SpriteRenderer spriteRenderer, float speed = 1f)
    {
        movementSpeed = speed;

        this.rigidbody = rigidbody;
        this.spriteRenderer = spriteRenderer;
    }

    #region Movement

    /// <summary>
    /// Moves the Character relative to movementDirection.
    /// </summary>
    /// <param name="movementDirection">The movement direction in which the Character should move.</param>
    /// <param name="sprinting">Controls if the Character should move at sprint speed.</param>
    public virtual void Move(Vector2 movementDirection, bool sprinting = false)
    {
        if (!canMove) return;

        Vector3 movement;
        float speed;

        //Speed modifiers
        if (sprinting)
            speed = movementSpeed + (movementSpeed / 100 * PERCENTAGE_INCREASE_WHEN_SPRINTING);
        else
            speed = movementSpeed;

        //Controls sprite look direction
        if (spriteRenderer != null)
        {
            if (movementDirection.x < 0)
                spriteRenderer.flipX = true;
            else if (movementDirection.x > 0)
                spriteRenderer.flipX = false;
        }

        //Moving the Character
        movement = new Vector2(movementDirection.x, movementDirection.y) * Time.deltaTime * speed;
        rigidbody.transform.Translate(movement, Space.World);
    }
    #endregion
}
