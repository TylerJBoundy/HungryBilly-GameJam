using UnityEngine;
using UnityEngine.UI;

public class UI_Lifeforce : MonoBehaviour
{
    private Player player;
    [SerializeField] private Image lifeBar;
    [SerializeField] private TMPro.TextMeshProUGUI lifeAmount;

    private void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// Updates the lifeforce visual with new values.
    /// </summary>
    /// <param name="health">The lifeforce of the player.</param>
    /// <param name="maxHealth">The max lifeforce of the player.</param>
    private void UpdateVisuals(int health, int maxHealth)
    {
        //float startValue = lifeBar.fillAmount;

        //float timer = 0f;
        //timer += Time.deltaTime;

        //float displayValue = Mathf.Lerp(startValue, (float)health / maxHealth, timer);
        //lifeBar.fillAmount = displayValue;

        lifeBar.fillAmount = (float)health / maxHealth;

        lifeAmount.text = health.ToString();
    }

    private void Update() => UpdateVisuals(player.Life.Life, player.Life.MaxLife);
}
