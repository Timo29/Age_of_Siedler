using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
    public ReworkedMapGenerator mapGenerator;
    public RecourceManagement recourceMapGenerator;
    public MeshCombiner combiner;

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
