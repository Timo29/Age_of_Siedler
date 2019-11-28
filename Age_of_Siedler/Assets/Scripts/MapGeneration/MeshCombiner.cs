using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public GameObject ground;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CombineByMaterial();
            SetLayer();
        }
    }

    public void SetLayer()
    {
        ground = GameObject.Find("CombinedMesh_GrasBlock (UnityEngine.Material)");
        ground.layer = 9;
    }

    public void CombineByMaterial()
    { 
        Dictionary<Material, List<GameObject>> gosByMaterial = new Dictionary<Material, List<GameObject>>();
        List<GameObject> tempGos = new List<GameObject>();
        List<GameObject> combinedGameObjects = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Material tempMat = transform.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial;
            GameObject tempGo = transform.GetChild(i).gameObject;
            tempGos = new List<GameObject>();

            gosByMaterial.TryGetValue(tempMat, out tempGos);

            if (tempGos != null)
            {
                tempGo = transform.GetChild(i).gameObject;
                tempGos.Add(tempGo);
                gosByMaterial.Remove(tempMat);
                gosByMaterial.Add(tempMat, tempGos);
            }
            else
            {
                tempGos = new List<GameObject>();
                tempGos.Add(tempGo);
                gosByMaterial.Add(tempMat, tempGos);
            }
        }


        CombineInstance[] combine = new CombineInstance[transform.childCount];
        Material mat = null;

        foreach (var key in gosByMaterial.Keys)
        {
            tempGos = new List<GameObject>();
            gosByMaterial.TryGetValue(key, out tempGos);

            if (tempGos == null)
            {
                Debug.LogError("FEHLER!");
            }
            else
            {
                combine = new CombineInstance[transform.childCount];
                mat = null;

                mat = tempGos[0].GetComponent<MeshRenderer>().sharedMaterial;

                for (int i = 0; i < tempGos.Count; i++)
                {
                    combine[i].mesh = tempGos[i].GetComponent<MeshFilter>().sharedMesh;
                    combine[i].transform = tempGos[i].transform.localToWorldMatrix;
                    tempGos[i].SetActive(false);
                }

                GameObject go = new GameObject("CombinedMesh_" + key);
                MeshFilter mf =go.AddComponent<MeshFilter>();
                MeshRenderer mr = go.AddComponent<MeshRenderer>();
                go.transform.parent = transform;

                mf.sharedMesh = new Mesh();
                mf.sharedMesh.CombineMeshes(combine);
                mr.material = mat;

                combinedGameObjects.Add(go);
            }
        }

        //FinalCombine(combinedGameObjects);
    }

    public void FinalCombine(List<GameObject> combinedGameObjects)
    {
        CombineInstance[] combineFinal = new CombineInstance[combinedGameObjects.Count];
        Material[] materials = new Material[combinedGameObjects.Count];

        for (int i = 0; i < combinedGameObjects.Count; i++)
        {
            combineFinal[i].mesh = combinedGameObjects[i].GetComponent<MeshFilter>().sharedMesh;
            combineFinal[i].transform = combinedGameObjects[i].transform.localToWorldMatrix;
            combinedGameObjects[i].SetActive(false);
            materials[i] = combinedGameObjects[i].GetComponent<MeshRenderer>().sharedMaterial;
        }

        transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combineFinal, false);

        transform.GetComponent<MeshRenderer>().materials = materials;

        transform.gameObject.SetActive(true);
    }

    public void Combine()
    {
        CombineInstance[] combine = new CombineInstance[transform.childCount];
        Material[] materials = new Material[transform.childCount];


        for (int i = 0; i<transform.childCount; i++)
        {
            //if (!transform.GetChild(i).gameObject.activeInHierarchy)
            //    continue;

            combine[i].mesh = transform.GetChild(i).GetComponent<MeshFilter>().sharedMesh;
            combine[i].transform = transform.GetChild(i).localToWorldMatrix;
            transform.GetChild(i).gameObject.SetActive(false);
            materials[i] = transform.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial;
        }

        transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine, false);

        transform.GetComponent<MeshRenderer>().materials = materials;

        transform.gameObject.SetActive(true);

    }
}
