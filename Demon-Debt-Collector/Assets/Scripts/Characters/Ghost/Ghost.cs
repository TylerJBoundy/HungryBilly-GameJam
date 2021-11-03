using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private Ghost_Move movement;
    [SerializeField] private Transform[] destinations;

    private int targetIndex = 0;

    private void Start()
    {
        movement = new Ghost_Move(GetComponent<Rigidbody2D>(), GetComponent<Collider2D>(), GetComponent<SpriteRenderer>());
    }

    private void GetNewTarget()
    {
        targetIndex++;
        if (targetIndex > destinations.Length) targetIndex = 0;
    }

    private void Update()
    {
        movement.Move(destinations[targetIndex].position);
        if (transform.position == destinations[targetIndex].position) GetNewTarget();
    }
}
