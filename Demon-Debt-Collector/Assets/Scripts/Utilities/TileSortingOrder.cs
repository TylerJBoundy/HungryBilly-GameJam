using UnityEngine;

public class TileSortingOrder : MonoBehaviour
{
    private Player player;
    private SpriteRenderer spriteRenderer;
    private int mode = 0;

    [SerializeField] private int orderOffset = 1;

    void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            if (mode == 1 || mode == 0)
            {
                mode = 2;
                spriteRenderer.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + orderOffset;
            }
        }
        else if (player.transform.position.y <= transform.position.y)
        {
            if (mode == 2 || mode == 0)
            {
                mode = 1;
                spriteRenderer.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - orderOffset;
            }
        }
    }
}
