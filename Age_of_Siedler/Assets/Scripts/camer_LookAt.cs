//Autor: Stöckmann Timo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer_LookAt : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //richtet das Resourcen Canvas zur Camera aus
        transform.LookAt(Camera.main.transform.position);
    }
}
