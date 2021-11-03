using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private Player player;

    [Header("Stats")]
    [SerializeField] private int score = 0;
    [SerializeField] private int ghostsDrained = 0, peopleHealed = 0;
    public int Score => score;
    public int GhostsDrained => ghostsDrained;
    public int PeopleHealed => peopleHealed;

    [Header("Enemies in scene")]
    [SerializeField] private int ghostsAvailable = 0;
    [SerializeField] private int peopleAvailable = 0;

    [Header("Constraints")]
    [SerializeField] private int maxGhosts = 5;
    [SerializeField] private int maxPeople = 10;

    [Header("Enemy Spawning Variables")]
    [SerializeField] private Transform[] ghostSpawnpoints;
    [SerializeField] private Transform[] peopleSpawnpoints;
    [SerializeField] private GameObject ghostPrefab, personPrefab;
    [SerializeField] private Transform enemyDump;
    [Space]
    [SerializeField] private float ghostMaxWanderDistance = 1f;

    public void AddScore(int amount) => score += amount;

    private void Awake()
    {
        if (player == null) player = FindObjectOfType<Player>();

        for (int i = 0; i < maxGhosts; i++) { SpawnGhost(); }
        for (int i = 0; i < maxPeople; i++) { SpawnPerson(); }
    }

    #region Rewards
    /// <summary>
    /// Fired when a ghost is drained.
    /// </summary>
    /// <param name="reward">The reward to be given to the player.</param>
    public void GhostDrained(Enemy.KillReward reward)
    {
        //rewards
        player.Life.AddLife(reward.life);
        AddScore(reward.score);

        ghostsAvailable--;
        ghostsDrained++;
        if (ghostsAvailable < maxGhosts) SpawnGhost();
    }

    /// <summary>
    /// Fired when a WhickedPerson is healed.
    /// </summary>
    /// <param name="reward">The reward to be given to the player.</param>
    public void PersonHealed(Enemy.KillReward reward)
    {
        //rewards
        player.Life.AddLife(reward.life);
        AddScore(reward.score);

        peopleAvailable--;
        peopleHealed++;
        if (peopleAvailable < maxPeople) SpawnPerson();
    }
    #endregion
    #region Spawners
    /// <summary>
    /// Spawn a Ghost at a random ghost spawn point.
    /// Randomly adds 2-5 destinations for the ghost with a 1f distance from their spawn on x+- and y+-.
    /// </summary>
    public void SpawnGhost()
    {
        if (ghostsAvailable >= maxGhosts) return;

        Transform spawnpoint = ghostSpawnpoints[Random.Range(0, ghostSpawnpoints.Length - 1)]; //set the spawnpoint to a random one in the list
        Ghost ghost = Instantiate(ghostPrefab, spawnpoint).GetComponent<Ghost>(); //instantiate a ghost at spawnpoint.
        ghost.transform.SetParent(enemyDump); //puts the ghost in the enemydump gameobject

        List<Vector2> destinations = new List<Vector2>(); //adds random destinations for the ghost movement AI.
        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            Vector2 newDestination = new Vector2(
                Random.Range(
                    spawnpoint.position.x - ghostMaxWanderDistance, 
                    spawnpoint.position.x + ghostMaxWanderDistance
                    ), 
                Random.Range(
                    spawnpoint.position.y - ghostMaxWanderDistance, 
                    spawnpoint.position.y + ghostMaxWanderDistance
                    )
                );

            destinations.Add(newDestination);
        }
        ghost.SetDestinations(destinations.ToArray());

        ghostsAvailable++;
    }

    /// <summary>
    /// Spawns a WhickedPerson at a random person spawn point.
    /// </summary>
    public void SpawnPerson()
    {
        if (peopleAvailable >= maxPeople) return;

        Transform spawnpoint = peopleSpawnpoints[Random.Range(0, peopleSpawnpoints.Length - 1)];
        WhickedPerson person = Instantiate(personPrefab, spawnpoint).GetComponent<WhickedPerson>();
        person.transform.SetParent(enemyDump);

        peopleAvailable++;
    }
    #endregion
}
