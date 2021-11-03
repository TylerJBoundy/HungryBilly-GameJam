using System.Collections;
using System.Collections.Generic;
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

    private void UpdateVisuals() => scoreText.text = $"Score: {gm.Score}";
}
