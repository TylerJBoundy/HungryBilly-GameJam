using UnityEngine;
using UnityEngine.UI;

public class UI_Lifeforce : MonoBehaviour
{
    private Player player;
    [SerializeField] private Image lifeBar;

    private void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
    }

    private void UpdateVisuals(float health, float maxHealth)
    {
        lifeBar.fillAmount = health / maxHealth;
    }

    private void Update()
    {
        UpdateVisuals(player.Life.Life, player.Life.MaxLife);
    }
}
