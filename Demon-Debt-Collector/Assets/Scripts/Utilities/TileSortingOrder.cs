using UnityEngine;

public class TileSortingOrder : MonoBehaviour
{
    private Player player;
    private SpriteRenderer spriteRenderer;
    private int Mode;

    [SerializeField] private int orderOffset = 1;

    void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        Mode = 0;
    }

    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            if (Mode == 1 || Mode == 0)
            {
                Mode = 2;
                spriteRenderer.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + orderOffset;
            }
        }
        else if (player.transform.position.y <= transform.position.y)
        {
            if (Mode == 2 || Mode == 0)
            {
                Mode = 1;
                spriteRenderer.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - orderOffset;
            }
        }
    }
}
