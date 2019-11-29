//Autor: Maximilian Dorn
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ReworkedMapGenerator : MonoBehaviour
{
    [Header("Block Prefabs")]
    public GameObject groundBlock;

    [Header("Seed Settings")]
    public string seed;
    public bool useRandomSeed;

    public bool GROUND = true;
    public bool WALL = false;

    public bool[,] map;
    public Transform[,] gameMap;

    [Header("Map Width + Height")]
    public int width;
    public int height;

    [Header("Chance for Water/Ground")]
    [Range(0, 100)]
    public int randomFillPercent;

    [Header("Developer Settings")]
    public int normalizeCount = 4;

    public int extendedWater = 100;

    private bool activateOnce = false;
    public Material grasMat;
    public Material waterMat;

    public bool IsGround(int x, int y)
    {
        return map[x, y];
    }


    private void Start()
    {
        width = width + extendedWater;
        height = height + extendedWater;
    }

    public void GenerateMap()
    {
        InstantiateMapValues();     
        FillMap();
    }

    public void InstantiateMapValues()
    {
        System.Random random = new System.Random(seed.GetHashCode());

        map = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x < extendedWater/2 || x > width - extendedWater/2 || y < extendedWater/2 || y > width - extendedWater/2)
                {
                    map[x, y] = WALL;
                }
                else
                {
                    var chance = random.Next(0, 100);
                    if (chance > randomFillPercent)
                    {
                        map[x, y] = GROUND;
                    }
                    else
                    {
                        map[x, y] = WALL;
                    }
                }
            }
        }
        NormalizeMap(normalizeCount);
    }

    public void FillMap()
    {

        gameMap = new Transform[width, height];


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bool state = IsGround(x, y);
                GameObject block;
                if (state)
                {
                    block = Instantiate(groundBlock, transform, false);
                    block.GetComponent<Renderer>().sharedMaterial = grasMat;
                    block.transform.localPosition = new Vector3(x, 0, y);
                }
                else
                {
                    block = Instantiate(groundBlock, transform, false);
                    block.GetComponent<Renderer>().sharedMaterial = waterMat;
                    block.layer = 0;
                    block.transform.localPosition = new Vector3(x, 0, y);
                }
                gameMap[x, y] = block.transform;
            }
        }
    }

    public void NormalizeMap(int rounds)
    {
        var temp = new bool[width, height];
        for (int i = 0; i < rounds; i++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int wall = CountNeighbours(x, y);
                    if (map[x, y])
                    {
                        if(wall > 4)
                        {
                            temp[x, y] = WALL;
                        }
                        else
                        {
                            temp[x, y] = GROUND;
                        }
                    }
                    else
                    {
                        if(wall < 2)
                        {
                            temp[x, y] = GROUND;
                        }
                        else
                        {
                            temp[x, y] = WALL;
                        }
                    }
                }
            }
        var copy = map;
        map = temp;
        temp = copy;

        }
    }

    private int CountNeighbours(int x, int y)
    {
        int wallCount = 0;

        for (int gridX = -1; gridX < 2; gridX++)
        {
            for (int gridY = -1; gridY < 2; gridY++)
            {
                if (gridX == 0 && gridY == 0)
                {
                    continue;
                }
                if (!map[x + gridX, y + gridY])
                {
                    wallCount += 1;
                }
            }
        }

        return wallCount;
    }
}
