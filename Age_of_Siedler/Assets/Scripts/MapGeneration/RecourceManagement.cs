using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceManagement : MonoBehaviour
{
    public ReworkedMapGenerator map;

    public GameObject[] stoneBlock = null;
    public GameObject[] woodBlock = null;

    public int width;
    public int height;

    public Transform[,] recourceMapBlocks;
    public int[,] recourceMap;

    [Header("Chance for Recources to Spawns")]
    [Range(0, 100)]
    public int recourceChance;

    [Header("Wood Stone Ratio")]
    [Range(0, 100)]
    public int woodStoneRatio;

    private void SetWidthAndHeight()
    {
        width = map.width;
        height = map.height;
    }

    private void InstantiateRecourceMapValues()
    {
        recourceMap = new int[width, height];

        //if (useRandomSeed)
        //{
        //    seed = Time.time.ToString();
        //}

        //System.Random random = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map.map[x, y] == map.GROUND)
                {
                    //var chance = random.Next(0, 100);
                    //var chance = UnityEngine.Random.Range(0, 100);
                    if (UnityEngine.Random.Range(0, 100) > recourceChance)
                    {
                        if (UnityEngine.Random.Range(0, 100) > woodStoneRatio)
                        {
                            recourceMap[x, y] = 1;
                        }
                        else //if (chance < woodStoneRatio)
                        {
                            recourceMap[x, y] = 2;
                        }
                    }
                    //else
                    //{
                    //    recourceMap[x, y] = 0;
                    //}
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
                    //May delete 0.5f afterwards
                    block2 = Instantiate(stoneBlock[UnityEngine.Random.Range(0, stoneBlock.Length - 1)], transform, false);
                    //block2.transform.Rotate(0, UnityEngine.Random.Range(0, 360), 0);
                    block2.transform.localPosition = new Vector3(x + 0.5f, 0, y + 0.5f);
                }
                else if (recourceMap[x, y] == 2)
                {
                    block2 = Instantiate(woodBlock[UnityEngine.Random.Range(0, woodBlock.Length - 1)], transform, false);
                    //block2.transform.Rotate(0, UnityEngine.Random.Range(0, 360), 0);
                    block2.transform.localPosition = new Vector3(x + 0.5f, 0, y + 0.5f);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Instantiate");
            SetWidthAndHeight();
            InstantiateRecourceMapValues();
            FillRecourceMap();
        }
    }
}
