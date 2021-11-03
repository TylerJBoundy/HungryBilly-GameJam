using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Rewards")]
    [SerializeField] protected int reward = 10;
    public int Reward => reward;

    [Header("Movement Variables")]
    [SerializeField] protected float startingSpeed = 1f;

    public virtual void Dead() => Destroy(gameObject);
}

public enum EnemyTypes
{
    GHOST,
    WHICKED_PERSON,
}
