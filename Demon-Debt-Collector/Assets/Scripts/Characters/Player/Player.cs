using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Life Variables")]
    [SerializeField] private Lifeforce lifeforce;

    [Header("Movement Variables")]
    [SerializeField] private float startingSpeed = 1f;
    [SerializeField] private Player_Move movement;
    public Player_Move Movement => movement;

    [Header("Customisable Variables")]
    [SerializeField] private float interactRadius = 10f;
    [SerializeField] private float absorbDuration = 5f;

    [Header("Debugging")]
    public bool busy = false;


    private Player_Input input;
    public Player_Input Input => input;

    [SerializeField] private AbsorbLife absorbLife;

    public Lifeforce Life => lifeforce;

    private void Start()
    {
        movement = new Player_Move(startingSpeed, GetComponent<Rigidbody2D>(), GetComponent<SpriteRenderer>());
        input = new Player_Input();

        absorbLife = AbsorbLife.CreateComponent(gameObject, absorbDuration);
    }

    
    private void FixedUpdate()
    {
        //move
        movement.Move(input.Move, input.IsSprinting);

        //drain life
        if (!lifeforce.Draining) StartCoroutine(lifeforce.DrainLife());

        //absorb from enemies
        Enemy target = absorbLife.CheckSurroundings(interactRadius);
        if (input.AbsorbingLife && target != null && busy == false) absorbLife.StartAbsorb(target);
    }

    #region Unity new input system (OnEnable/OnDisable)
    private void OnEnable() => input.OnEnable();
    private void OnDisable() => input.OnDisable();
    #endregion
}
