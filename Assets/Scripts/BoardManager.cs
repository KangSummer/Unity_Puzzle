using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Memory Pool


public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;                                                      // Create Singleton

    public List<GameObject> m_Characters = new List<GameObject>();                     //  Tile Image List

    public GameObject m_Tile;                                                                           // Tile Prefab 

    public int m_SizeX;                                                                                          // Tile SizeX
    public int m_SizeY;                                                                                          // Tile SizeY

    private GameObject[,] m_Tiles;                                                                  // Tile Array 

    public bool IsShifting { get; set; }                                                                // Board reset

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<BoardManager>();                                                            // Singleton 설정
        Vector2 offset = m_Tile.GetComponent<SpriteRenderer>().bounds.size;         // Sprite Size

        CreateBackGround(offset.x, offset.y);
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float _fOffsetX, float _fOffsetY)
    {
        m_Tiles = new GameObject[m_SizeX, m_SizeY];

        float fStartX = transform.position.x;
        float fStartY = transform.position.y;

        GameObject[] PreviousLeft = new GameObject[m_SizeY];
        GameObject PreviousBelow = null;

        for (int x = 0; x < m_SizeX; ++x)
        {
            for (int y = 0; y < m_SizeY; ++y)
            {
                List<GameObject> PossibleCharacters = new List<GameObject>();
                PossibleCharacters.AddRange(m_Characters);

                PossibleCharacters.Remove(PreviousLeft[y]);
                PossibleCharacters.Remove(PreviousBelow);

                GameObject Tile = PossibleCharacters[Random.Range(0, PossibleCharacters.Count)];

                GameObject newTile = Instantiate(Tile, new Vector3(fStartX + (_fOffsetX * x), fStartY + (_fOffsetY * y), 0),  m_Tile.transform.rotation);
                m_Tiles[x, y] = newTile;

                newTile.transform.parent = transform;
                //GameObject newGameObject = PossibleCharacters[Random.Range(0, PossibleCharacters.Count)];
                //newTile = newGameObject;

                //PreviousLeft[y] = newGameObject;
                //PreviousBelow = newGameObject;
            }
        }
    }

    public GameObject m_BackGround;                                                         // BackGround Prefab
    private GameObject[,] m_BackGroundTile;                                             // BackGroundTile Array
   private void CreateBackGround(float _fOffsetX, float _fOffsetY)
    {
        m_BackGroundTile = new GameObject[m_SizeX, m_SizeY];
        float fStartX = transform.position.x;
        float fStartY = transform.position.y;

        
        for (int x = 0; x < m_SizeX; ++x)
        {
            for (int y = 0; y < m_SizeY; ++y)
            {
                GameObject newTile = Instantiate(m_BackGround, new Vector3(fStartX + (_fOffsetX * x), fStartY + (_fOffsetY * y), 1), m_BackGround.transform.rotation);
                m_BackGroundTile[x, y] = newTile;

                newTile.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
    }
}
