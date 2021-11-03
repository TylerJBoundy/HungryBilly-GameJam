using UnityEngine;

public class Ghost : Enemy
{
    #region AI
    [Header("Movement Variables")]
    [SerializeField] protected float startingSpeed = 1f; //Speed to start with
    [SerializeField] private Ghost_Move movement; //Movement module for the character
    [SerializeField] private Vector2[] destinations; //used to control the AI movement

    public Ghost_Move Movement => movement;

    //used as a reference for which destination is currently active for the AI
    private int targetIndex = 0;

    public void SetDestinations(Vector2[] destinations) => this.destinations = destinations;

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
    #endregion

    public override void Dead() //handles further death behaviour for the ghost character
    {
        gm.GhostDrained(reward);
        base.Dead();
    }
}
