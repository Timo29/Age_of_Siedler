using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
    public ReworkedMapGenerator mapGenerator;
    public RecourceManagement recourceMapGenerator;
    public MeshCombiner combiner;

    public delegate void BackeNavMesh ();
    public static event BackeNavMesh onStartMap;

    public delegate void ClearArea();
    public static event ClearArea onCompliteMapBuild;

    IEnumerator MapInitialize()
    {       
        mapGenerator.GenerateMap();
        Debug.Log("1");
        recourceMapGenerator.GenerateRecources();
        Debug.Log("2");

        yield return new WaitForSeconds(5f);
        combiner.CombineByMaterial();
        Debug.Log("3");
        combiner.SetLayer();
        yield return new WaitForSeconds(1f);
        Debug.Log("4");
        onStartMap();
        yield return new WaitForSeconds(2f);
        onCompliteMapBuild();

        yield return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MapInitialize");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
