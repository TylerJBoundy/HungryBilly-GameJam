using UnityEngine;

public class Ghost : Enemy
{
    [SerializeField] private Ghost_Move movement;
    public Ghost_Move Movement => movement;

    [SerializeField] private Vector2[] destinations;

    private int targetIndex = 0;

    private void Start()
    {
        movement = new Ghost_Move(startingSpeed, GetComponent<Rigidbody2D>(), GetComponent<SpriteRenderer>());
    }

    /// <summary>
    /// Sets a new target for the AI.
    /// </summary>
    private void GetNewTarget()
    {
        targetIndex++;
        if (targetIndex == destinations.Length) targetIndex = 0;
    }

    private void FixedUpdate()
    {
        if (destinations.Length != 0) //Checks if the AI has any target destinations to travel to.
        {
            //it does.
            if ((Vector2)transform.position == destinations[targetIndex]) GetNewTarget(); //Check if the AI has arrived.
            movement.Move(destinations[targetIndex]); //Move towards the destination.
        }
    }
}
