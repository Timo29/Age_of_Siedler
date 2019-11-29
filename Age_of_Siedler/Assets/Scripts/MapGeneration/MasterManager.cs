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
        recourceMapGenerator.GenerateRecources();

        yield return new WaitForSeconds(5f);
        combiner.CombineByMaterial();
        combiner.SetLayer();
        yield return new WaitForSeconds(1f);
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
