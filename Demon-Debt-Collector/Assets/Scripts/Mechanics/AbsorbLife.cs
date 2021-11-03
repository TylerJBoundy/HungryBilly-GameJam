using System.Collections;
using UnityEngine;

public class AbsorbLife : MonoBehaviour
{
    private Player player;

    [SerializeField] private int absorbScore = 0;
    [SerializeField] private int requiredScore = 10;

    [SerializeField] private float absorbDuration = 1f;

    /// <summary>
    /// Creates this script as a component on a given game object.
    /// </summary>
    /// <param name="where">Where to add the Component.</param>
    /// <param name="absorbDuration">base value for absorbDuration.</param>
    /// <returns>The newly added component.</returns>
    public static AbsorbLife CreateComponent(GameObject where, float absorbDuration)
    {
        AbsorbLife newComponent = where.AddComponent<AbsorbLife>();
        newComponent.absorbDuration = absorbDuration;
        return newComponent;
    }

    private void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
    }


    private EnemyTypes CheckEnemyType(Enemy enemy)
    {
        if (enemy as Ghost != null)
            return EnemyTypes.GHOST;
        else if (enemy as WhickedPerson != null)
            return EnemyTypes.WHICKED_PERSON;

        return EnemyTypes.INVALID;
    }

    #region Absorbing Lifeforce
    /// <summary>
    /// Starts absorbing target.
    /// </summary>
    /// <param name="target">The target to absorb.</param>
    public void StartAbsorb(Enemy target)
    {
        player.busy = true;
        absorbScore = 0;
        player.Movement.canMove = false;
        ControlEnemyMovement(target);
        StartCoroutine(Absorb(target));
    }

    /// <summary>
    /// A coroutine that handles absorbing the target over time.
    /// </summary>
    /// <param name="target">The target to absorb.</param>
    IEnumerator Absorb(Enemy target)
    {
        if (!player.Input.AbsorbingLife)
        {
            EndAbsorb(target, false);
            yield break;
        }

        if (absorbScore == 0)
        {
            Animator animator = target.GetComponent<Animator>();
            animator.SetBool("Draining", true);
            animator.PlayInFixedTime("Drain", 1, absorbDuration);
        }
        else if (absorbScore == requiredScore)
        {
            EndAbsorb(target, true);
            yield break;
        }

        yield return new WaitForSeconds(absorbDuration / requiredScore);

        absorbScore++;
        StartCoroutine(Absorb(target));
    }

    /// <summary>
    /// Ends the absorbing of a target.
    /// </summary>
    /// <param name="target">The target to stop absorbing.</param>
    /// <param name="successful">Whether or not the target was completely absorbed.</param>
    private void EndAbsorb(Enemy target, bool successful = false)
    {
        if (successful)
        {
            target.Dead();
        }
        else
        {
            target.GetComponent<Animator>().SetBool("Draining", false);
            ControlEnemyMovement(target, true);
        }

        player.Movement.canMove = true;
        player.busy = false;
    }
    #endregion

    /// <summary>
    /// Handles Freezing AI movement and Thawing AI movement.
    /// </summary>
    /// <param name="target">The AI to handle.</param>
    /// <param name="thaw">
    /// True if method should thaw AI movement.
    /// False if method should freeze AI movement.
    /// </param>
    private void ControlEnemyMovement(Enemy target, bool thaw = false)
    {
        switch (CheckEnemyType(target))
        {
            case EnemyTypes.INVALID:
                Debug.Log("that's weird....");
                break;
            case EnemyTypes.GHOST:
                Ghost ghost = target as Ghost;
                ghost.Movement.canMove = thaw;
                break;
            case EnemyTypes.WHICKED_PERSON:
                WhickedPerson wp = target as WhickedPerson;
                //wp.Movement.canMove = thaw;
                break;
        }
    }

    /// <summary>
    /// Checks the surroundings of the player within interactRadius.
    /// </summary>
    /// <param name="interactRadius">The radius in which to check.</param>
    /// <returns>A target within the given radius.</returns>
    public Enemy CheckSurroundings(float interactRadius)
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        foreach (Collider2D collider2D in collider2DArray)
        {
            var collision = collider2D.GetComponent<Enemy>();
            if (collision != null) return collision;
        }

        return null;
    }
}
