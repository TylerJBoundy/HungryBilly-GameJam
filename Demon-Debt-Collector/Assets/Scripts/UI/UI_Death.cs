using System.Collections;
using System.Collections.Generic;
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

    public void Respawn() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    private void ShowDeathScreen()
    {
        if (player.IsInvinsible) return;

        deathScreen.alpha = 1;
        UpdateVisuals();
    }

    private void HideDeathScreen() => deathScreen.alpha = 0;

    private void UpdateVisuals()
    {
        scoreText.text = $"Score: {gm.Score}";
        ghostsDrainedText.text = $"Ghosts Drained: {gm.GhostsDrained}";
        peopleHealedText.text = $"People Healed: {gm.PeopleHealed}";
    }
}
