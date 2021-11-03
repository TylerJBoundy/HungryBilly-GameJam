using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Basic Variables")]
    [SerializeField] private Texture2D levelTexture;
    [SerializeField] private Transform mapDump;
    private Color[] tileColours;
    private int levelWidth;
    private int levelHeight;

    [Header("Tiles")]
    [SerializeField] private Tile[] tiles;

    [System.Serializable]
    private class Tile
    {
        [HideInInspector] public string name;
        public Transform prefab;
        public Color colour;
    }

    private void OnValidate()
    {
        foreach (Tile tile in tiles)
        {
            tile.name = tile.prefab.name;
        }
    }

    private void Start()
    {
        levelWidth = levelTexture.width;
        levelHeight = levelTexture.height;
        LoadLevel();
    }

    private void LoadLevel()
    {
        tileColours = new Color[levelWidth * levelHeight];
        tileColours = levelTexture.GetPixels();

        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                foreach (Tile tile in tiles)
                {
                    if (tileColours[x + y * levelWidth] == tile.colour)
                    {
                        Transform newTile = Instantiate(tile.prefab, new Vector2(x, y), Quaternion.identity);
                        newTile.SetParent(mapDump);
                    }
                }
            }
        }
    }
}
