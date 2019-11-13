using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_v2 : MonoBehaviour
{
    public Camera camera;

    public GameObject currentResident;
    internal int currentResidentHash;
    public Resources currentResourc;
    public Vector3 currentTarget;

    private int lastResident;


    void Update()
    {
        RaycastHit hitInfo;

        if (Input.GetButtonUp("Fire1"))
        {
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hitInfo.transform.tag == "resident")
            {
                if (currentResident != hitInfo.transform.gameObject)
                {
                    if (currentResident != null)
                    {
                        currentResident.GetComponent<Player>().mark.SetActive(false);
                    }
                    currentResident = hitInfo.transform.gameObject;
                    currentResident.GetComponent<Player>().mark.SetActive(true);  
                }
            }
            else
            {
                if (currentResident != null)
                {
                    currentResident.GetComponent<Player>().mark.SetActive(false);
                    currentResident = null;
                }

            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (currentResident != null)
            {
                Debug.Log(hitInfo.transform.tag + " Target Tag");

                if (hitInfo.transform.tag != "work")
                {
                    currentResident.GetComponent<Player>().isWorking = false;
                    currentTarget = hitInfo.point;

                    currentResident.GetComponent<Player>().target = currentTarget;

                    currentResident.GetComponent<Animator>().SetBool("isMoving", true); 
                }
                else if(hitInfo.transform.tag == "work")
                {
                    currentTarget = hitInfo.point;
                    
                    currentResident.GetComponent<Player>().target = currentTarget;
                    currentResident.GetComponent<Player>().workResource = hitInfo.transform.gameObject.GetComponent<Resource>();
                    currentResident.GetComponent<Player>().isWorking = true;
                    currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                }
            }
        }
    }
}
