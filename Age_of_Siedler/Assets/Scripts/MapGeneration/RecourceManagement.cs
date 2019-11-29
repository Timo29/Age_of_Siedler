//Autor: Maximilian Dorn
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceManagement : MonoBehaviour
{
    public ReworkedMapGenerator map;

    public bool rotationOn = false;

    public GameObject[] stoneBlock = null;
    public GameObject[] woodBlock = null;

    private int width;
    private int height;

    private Transform[,] recourceMapBlocks;
    private int[,] recourceMap;

    [Header("Chance for Recources to Spawns")]
    [Range(0, 100)]
    public int recourceChance;

    [Header("Wood Stone Ratio")]
    [Range(0, 100)]
    public int woodStoneRatio;


    public void GenerateRecources()
    {
        width = map.width;
        height = map.height;

        InstantiateRecourceMapValues();
        FillRecourceMap();
    }

    private void InstantiateRecourceMapValues()
    {
        recourceMap = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map.map[x, y] == map.GROUND)
                {
                    if (UnityEngine.Random.Range(0, 100) > recourceChance)
                    {
                        if (UnityEngine.Random.Range(0, 100) > woodStoneRatio)
                        {
                            recourceMap[x, y] = 1;
                        }
                        else
                        {
                            recourceMap[x, y] = 2;
                        }
                    }

                }
            }
        }
    }

    private void FillRecourceMap()
    {
        recourceMapBlocks = new Transform[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject block2;
                if (recourceMap[x, y] == 1)
                {
                    block2 = Instantiate(stoneBlock[UnityEngine.Random.Range(0, stoneBlock.Length)], transform, false);
                    if (rotationOn)
                    {
                    block2.transform.Rotate(0, UnityEngine.Random.Range(0, 360), 0);
                    }
                    block2.transform.localPosition = new Vector3(x + 0.5f, 0, y + 0.5f);
                }
                else if (recourceMap[x, y] == 2)
                {
                    block2 = Instantiate(woodBlock[UnityEngine.Random.Range(0, woodBlock.Length)], transform, false);
                    if (rotationOn)
                    {
                        block2.transform.Rotate(0, UnityEngine.Random.Range(0, 360), 0);
                    }
                    block2.transform.localPosition = new Vector3(x + 0.5f, 0, y + 0.5f);
                }
            }
        }
    }
}
