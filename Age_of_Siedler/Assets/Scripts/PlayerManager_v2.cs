//Autor: Stöckmann Timo
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
    public ParticleSystem hitPoint;


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
                        currentResident.GetComponent<Player>().canvas.SetActive(false);
                        currentResident.GetComponent<Player>().select.Stop();
                        currentResident.GetComponent<Player>().isSelect = false;
                    }
                    currentResident = hitInfo.transform.gameObject;
                    currentResident.GetComponent<Player>().canvas.SetActive(true);
                    currentResident.GetComponent<Player>().select.Play();
                    currentResident.GetComponent<Player>().isSelect = true;
                }
            }
            else
            {
                if (currentResident != null)
                {
                    currentResident.GetComponent<Player>().canvas.SetActive(false);
                    currentResident.GetComponent<Player>().select.Stop();
                    currentResident.GetComponent<Player>().isSelect = false;
                    currentResident = null;
                }

            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (currentResident != null)
            {
                Player player = currentResident.GetComponent<Player>();
                switch (hitInfo.transform.tag)
                {
                    case "resourceWood":
                        currentTarget = RandomPointInResource(hitInfo.transform.gameObject.transform.position);
                        player.target = currentTarget;
                        player.workResource = hitInfo.transform.gameObject.GetComponent<Resource>();
                        player.isWorking = true;
                        player.wood = true;
                        currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                        hitPoint.gameObject.transform.position = hitInfo.point;
                        hitPoint.Play();
                        break;
                    case "resourceStone":
                        currentTarget = RandomPointInResource(hitInfo.transform.gameObject.transform.position);
                        player.target = currentTarget;
                        player.workResource = hitInfo.transform.gameObject.GetComponent<Resource>();
                        player.isWorking = true;
                        player.stone = true;
                        currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                        hitPoint.gameObject.transform.position = hitInfo.point;
                        hitPoint.Play();
                        break;
                    case "building":
                        currentTarget = RandomPointInResource(hitInfo.transform.gameObject.transform.position);
                        player.target = currentTarget;
                        player.building = hitInfo.transform.gameObject.GetComponent<Building>();
                        player.isWorking = true;
                        player.build = true;
                        currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                        hitPoint.gameObject.transform.position = hitInfo.point;
                        hitPoint.Play();
                        break;
                    default:
                        currentTarget = hitInfo.point;
                        player.isWorking = false;
                        player.wood = false;
                        player.stone = false;
                        player.build = false;
                        player.target = currentTarget;
                        currentResident.GetComponent<Animator>().SetBool("isMoving", true);
                        hitPoint.gameObject.transform.position = hitInfo.point;
                        hitPoint.Play();
                        break;
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
