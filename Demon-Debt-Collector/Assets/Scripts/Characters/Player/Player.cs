using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Player_Input input;
    [SerializeField] private Player_Move movement;

    [SerializeField] private Lifeforce lifeforce;


    private void Start()
    {
        movement = new Player_Move(GetComponent<Rigidbody2D>(), GetComponent<Collider2D>(), GetComponent<SpriteRenderer>());
        input = new Player_Input();
    }

    private void Update()
    {
        movement.Move(input.Move, input.IsSprinting);
    }

    #region Unity new input system (OnEnable/OnDisable)
    private void OnEnable() => input.OnEnable();
    private void OnDisable() => input.OnDisable();
    #endregion
}
