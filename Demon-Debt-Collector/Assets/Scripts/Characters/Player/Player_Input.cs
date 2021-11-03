using UnityEngine;

public class Player_Input
{
    private PlayerControls controls;

    private Vector2 move;
    public Vector2 Move => move;

    private bool isSprinting = false;
    public bool IsSprinting => isSprinting;

    private bool absorbingLife = false;
    public bool AbsorbingLife => absorbingLife;

    public Player_Input()
    {
        controls = new PlayerControls();
        OnEnable();

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        controls.Player.Sprint.performed += ctx => isSprinting = true;
        controls.Player.Sprint.canceled += ctx => isSprinting = false;

        controls.Player.AbsorbLife.performed += ctx => absorbingLife = true;
        controls.Player.AbsorbLife.canceled += ctx => absorbingLife = false;
    }

    #region Unity new input system (OnEnable/OnDisable)
    public void OnEnable() => controls.Enable();
    public void OnDisable() => controls.Disable();
    #endregion
}
