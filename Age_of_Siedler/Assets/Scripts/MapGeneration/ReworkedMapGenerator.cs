﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ReworkedMapGenerator : MonoBehaviour
{
    public GameObject grasBlock = null;
    public GameObject waterBlock = null;
    public GameObject stoneBlock = null;
    public GameObject woodBlock = null;

    public string seed;
    public bool useRandomSeed;

    public const bool GROUND = true;
    public const bool WALL = false;

    private bool[,] map;
    private int[,] recourceMap;
    private Transform[,] gameMap;
    private Transform[,] recourceMapBlocks;

    public int width;
    public int height;

    [Range(0, 100)]
    public int randomFillPercent;

    [Range(0, 100)]
    public int recourceChance;

    [Range(0, 100)]
    public int woodStoneRatio;

    public int normalizeCount = 4;


    public bool IsGround(int x, int y)
    {
        return map[x, y];
    }

    private void Start()
    {
        GenerateMap();
        GenerateRecources();
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
        InstantiateMapValues();     
        FillMap();
    }

    void GenerateRecources()
    {
        InstantiateRecourceMapValues();
        FillRecourceMap();
    }



    public void InstantiateMapValues()
    {
        Debug.Log("InstantiateMapValues");
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random random = new System.Random(seed.GetHashCode());

        map = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = WALL;
                }
                else
                {
                    var chance = random.Next(0, 100);
                    if(chance > randomFillPercent)
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
                    block = Instantiate(grasBlock, transform, false);
                    block.transform.localPosition = new Vector3(x, y, 0);
                }
                else
                {
                    block = Instantiate(waterBlock, transform, false);
                    block.transform.localPosition = new Vector3(x, y, 0);
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

    private void InstantiateRecourceMapValues()
    {
        recourceMap = new int[width, height];

        Debug.Log("InstantiateRecourceValues");
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random random = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x,y] == GROUND)
                {
                    var chance = random.Next(0, 100);
                    if(chance> recourceChance)
                    {
                        if(chance > woodStoneRatio)
                        {
                            Debug.Log("SetStone");
                            recourceMap[x, y] = 1;
                        }
                        else if (chance < woodStoneRatio)
                        {
                            Debug.Log("SetWood");
                            recourceMap[x, y] = 2;
                        }
                    }
                    else
                    {
                        recourceMap[x, y] = 0;
                    }
                }
            }
        }
        NormalizeMap(normalizeCount);
    }

    private void FillRecourceMap()
    {
        recourceMapBlocks = new Transform[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject block2;
                if (recourceMap[x,y] == 1)
                {
                    Debug.Log("SetStone");
                    block2 = Instantiate(stoneBlock, transform, false);
                    block2.transform.localPosition = new Vector3(x, y, 1);
                }
                else if(recourceMap[x,y] == 2)
                {
                    Debug.Log("SetWood");
                    block2 = Instantiate(woodBlock, transform, false);
                    block2.transform.localPosition = new Vector3(x, y, 1);
                }
            }
        }
    }
}
