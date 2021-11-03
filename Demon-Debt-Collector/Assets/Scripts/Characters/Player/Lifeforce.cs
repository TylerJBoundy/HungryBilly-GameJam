using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lifeforce
{
    [Header("Health")]
    [SerializeField] private float life = 10;
    [SerializeField] private float maxLife = 10;

    public float Life => life;
    public float MaxLife => maxLife;

    [Header("Customisable Variables")]
    [Tooltip("The time it takes your life bar to drain completely in seconds.")]
    [SerializeField] private float lifeDrainDuration;

    private bool draining = false;
    public bool Draining => draining;

    public IEnumerator DrainLife()
    {
        draining = true;
        life--;
        yield return new WaitForSeconds(lifeDrainDuration / maxLife);
        draining = false;
    }
}
