using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public string seed;
    public bool useRandomSeed;

    public GameObject grasPrefab;
    public GameObject waterPrefab;

    int[,] map;

    [Range(0, 100)]
    public int randomFillPercent;

    public int width;
    public int height;

    public int normalizeCount;


    private void Start()
    {
        GenerateMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateMap();
        }
    }

    void GenerateMap()
    {
        map = new int[width,height];
        RandomFillMap();

        for (int i = 0; i < normalizeCount; i++)
        {
            NormalizeMap();
        }
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random randomNumber = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(x==0 || x==width-1 ||y==0 || y== height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (randomNumber.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }
    }

    void NormalizeMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighborWallTiles = GetNeighbors(x, y);

                    if(neighborWallTiles > 4)
                    {
                        map[x, y] = 1;
                    }
                    else if (neighborWallTiles < 4)
                    {
                        map[x, y] = 0;
                    }

            }
        }
    }

    int GetNeighbors(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int x = gridX-1; x <= gridX+1; x++)
        {
            for (int y = gridY - 1; y <= gridY + 1; y++)
            {
                if(x >= 0 && y < width && y >= 0 && y < height)
                {
                    if(x != gridX || y != gridY)
                    {
                        wallCount += map[x, y];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
                Gizmos.DrawCube(pos, Vector3.one);
            }
        }
    }

    //private void FillMap()
    //{
    //    for (int x = 0; x < width; x++)
    //    {
    //        for (int y = 0; y < height; y++)
    //        {
    //            GameObject block;
    //            if(map[x,y] == 1)
    //            {
    //                block = Instantiate(grasPrefab, transform, false);
    //                block.transform.localPosition = new Vector3(x, y, 0);
    //            }
    //            else
    //            {
    //                block = Instantiate(waterPrefab, transform, false);
    //                block.transform.localPosition = new Vector3(x, y, 0);
    //            }
    //        }
    //    }
    //}
}
