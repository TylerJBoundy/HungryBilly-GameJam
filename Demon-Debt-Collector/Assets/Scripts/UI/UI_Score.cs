using UnityEngine;

public class UI_Score : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private void Start()
    {
        if (gm == null) gm = FindObjectOfType<GameMaster>();

        gm.OnScoreUpdated.AddListener(UpdateVisuals);
    }

    /// <summary>
    /// Updates the score visuals.
    /// </summary>
    private void UpdateVisuals() => scoreText.text = $"Score: {gm.Score}";
}
