using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public List<GameObject> stoneCatalog;
    public List<GameObject> woodCatalog;

    void Start()
    {
        Resource.onResourceDel += DeleteResourceFromDictionary;
        stoneCatalog = new List<GameObject>();
        woodCatalog = new List<GameObject>();
        AddAllResources();
    }

    private void DeleteResourceFromDictionary(GameObject deleteGameObject, string tag)
    {
        int tempHash;
        tempHash = deleteGameObject.GetHashCode();
        switch (tag)
        {
            case "resourceStone":
                for (int i = 0; i < stoneCatalog.Count; i++)
                {
                    if (stoneCatalog[i] == deleteGameObject)
                    {
                        stoneCatalog.RemoveAt(i);
                        return;
                    }
                }
                break;
            case "resourceWood":
                for (int i = 0; i < woodCatalog.Count; i++)
                {
                    if (woodCatalog[i] == deleteGameObject)
                    {
                        woodCatalog.RemoveAt(i);
                        return;
                    }
                }
                break;
            default:
                break;
        }
    }

    void AddAllResources()
    {
        GameObject[] allResourcesStone;
        GameObject[] allResourcesWood;

        allResourcesStone = GameObject.FindGameObjectsWithTag("resourceStone");
        allResourcesWood = GameObject.FindGameObjectsWithTag("resourceWood");

        for (int i = 0; i < allResourcesStone.Length; i++)
        {
            stoneCatalog.Add(allResourcesStone[i]);
        }

        for (int i = 0; i < allResourcesWood.Length; i++)
        {
            woodCatalog.Add(allResourcesWood[i]);
        }
    }
}
