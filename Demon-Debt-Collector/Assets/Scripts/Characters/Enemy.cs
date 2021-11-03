using UnityEngine;

public abstract class Enemy : MonoBehaviour //handles basic enemy functions and variables
{
    [Header("Rewards")]
    [SerializeField] protected KillReward reward;

    protected GameMaster gm;

    [System.Serializable]
    public class KillReward
    {
        public int life;
        public int score;

        public KillReward(int life, int score)
        {
            this.life = life;
            this.score = score;
        }
    }

    private void Awake() => gm = FindObjectOfType<GameMaster>();

    /// <summary>
    /// Fired when the enemy is killed. (drained or healed)
    /// </summary>
    public virtual void Dead() => Destroy(gameObject);
}

public enum EnemyTypes
{
    INVALID,
    GHOST,
    WHICKED_PERSON,
}
