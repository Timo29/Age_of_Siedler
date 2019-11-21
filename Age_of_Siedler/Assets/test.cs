using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Vector3 offSet = gameObject.transform.position - MousePoint();
        transform.position = MousePoint()/* - offSet*/;
    }

    private Vector3 MousePoint()
    {
        Vector3 mousPoint = Input.mousePosition;
        mousPoint.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        return mousPoint;
    }
}
