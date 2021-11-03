using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Death : MonoBehaviour
{
    private GameMaster gm;
    private CanvasGroup deathScreen;
    private Player player;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ghostsDrainedText;
    [SerializeField] private TextMeshProUGUI peopleHealedText;

    private void Start()
    {
        if (deathScreen == null) deathScreen = GetComponent<CanvasGroup>();
        if (gm == null) gm = FindObjectOfType<GameMaster>();
        if (player == null) player = FindObjectOfType<Player>();

        player.Life.OnDied.AddListener(ShowDeathScreen);
    }

    /// <summary>
    /// Reloads the current scene ("respawning" the player).
    /// </summary>
    public void Respawn() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    /// <summary>
    /// Shows the death screen alongside the end of game stats window.
    /// </summary>
    private void ShowDeathScreen()
    {
        if (player.IsInvinsible) return;

        deathScreen.alpha = 1;
        UpdateVisuals();
    }

    /// <summary>
    /// Hides the death screen.
    /// </summary>
    private void HideDeathScreen() => deathScreen.alpha = 0;

    /// <summary>
    /// Updates the stats visuals.
    /// </summary>
    private void UpdateVisuals()
    {
        scoreText.text = $"Score: {gm.Score}";
        ghostsDrainedText.text = $"Ghosts Drained: {gm.GhostsDrained}";
        peopleHealedText.text = $"People Healed: {gm.PeopleHealed}";
    }
}
