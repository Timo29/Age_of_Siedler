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

                if (hitInfo.transform.tag == "resourceWood" || hitInfo.transform.tag == "resourceStone")
                {
                    Player player = currentResident.GetComponent<Player>();
                    //currentTarget = hitInfo.point;
                    currentTarget = RandomPointInResource(hitInfo.transform.gameObject.transform.position);
                    player.target = currentTarget;
                    player.workResource = hitInfo.transform.gameObject.GetComponent<Resource>();
                    player.isWorking = true;
                    switch (hitInfo.transform.tag)
                    {
                        case "resourceWood":
                            Debug.Log("Wood");
                            player.wood = true;
                            break;
                        case "resourceStone":
                            Debug.Log("Stone");
                            player.stone = true;
                            break;

                        default:
                            break;
                    }

                    currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                }
                else
                {
                    Player player = currentResident.GetComponent<Player>();
                    currentTarget = hitInfo.point;
                    player.isWorking = false;
                    player.wood = false;
                    player.stone = false;
                    player.target = currentTarget;
                    currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                }
            }
        }
    }

    public static Vector3 RandomPointInResource(Vector3 zone)
    {
        return new Vector3(
            Random.Range(zone.x + 1.5f, zone.x - 1.5f),
            0.5f,
            Random.Range(zone.z + 1.5f, zone.z - 1.5f));
    }
}
