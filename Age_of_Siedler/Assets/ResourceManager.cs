using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Dictionary<int, GameObject> stoneCatalog;
    public Dictionary<int, GameObject> woodCatalog;

    void Start()
    {
        Resource.onResourceDel += DeleteResourceFromDictionary;
        stoneCatalog = new Dictionary<int, GameObject>();
        woodCatalog = new Dictionary<int, GameObject>();
        AddAllResources();
    }

    private void DeleteResourceFromDictionary(GameObject deleteGameObject, string tag)
    {
        int tempHash;
        tempHash = deleteGameObject.GetHashCode();
        switch (tag)
        {
            case "resourceStone":
                stoneCatalog.Remove(tempHash);
                break;
            case "resourceWood":
                Debug.Log(woodCatalog.Count + " vor der löschung");
                woodCatalog.Remove(tempHash);
                Debug.Log(woodCatalog.Count + " nach der löschung");
                break;
            default:
                break;
        }
        stoneCatalog.Remove(tempHash);
    }

    void AddAllResources()
    {
        GameObject[] allResourcesStone;
        GameObject[] allResourcesWood;

        allResourcesStone = GameObject.FindGameObjectsWithTag("resourceStone");
        allResourcesWood = GameObject.FindGameObjectsWithTag("resourceWood");

        for (int i = 0; i < allResourcesStone.Length; i++)
        {
            stoneCatalog.Add(allResourcesStone[i].GetHashCode(), allResourcesStone[i]);
        }

        for (int i = 0; i < allResourcesWood.Length; i++)
        {
            woodCatalog.Add(allResourcesWood[i].GetHashCode(), allResourcesWood[i]);
        }
    }
}
