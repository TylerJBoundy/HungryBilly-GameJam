using System.Collections;
using UnityEngine;

[System.Serializable]
public class Lifeforce
{
    [Header("Health")]
    [SerializeField] private int life = 10;
    [SerializeField] private int maxLife = 10;

    public int Life => life;
    public int MaxLife => maxLife;

    [Header("Customisable Variables")]
    [Tooltip("The time it takes your life bar to drain completely in seconds.")]
    [SerializeField] private float lifeDrainDuration;

    private bool draining = false;
    public bool Draining => draining;

    /// <summary>
    /// Handles the draining of life.
    /// </summary>
    public IEnumerator DrainLife()
    {
        draining = true;
        RemoveLife(1);
        yield return new WaitForSeconds(lifeDrainDuration / maxLife);
        draining = false;
    }

    /// <summary>
    /// Adds life to the player.
    /// </summary>
    /// <param name="amount">The amount to add.</param>
    public void AddLife(int amount)
    {
        life += amount;

        if (life > maxLife) life = maxLife;
    }

    /// <summary>
    /// Removes life from the player.
    /// </summary>
    /// <param name="amount">The amount to remove.</param>
    public void RemoveLife(int amount)
    {
        life -= amount;

        if (life <= 0)
        {
            Debug.Log("dead");
            life = 0;
        }
    }
}
