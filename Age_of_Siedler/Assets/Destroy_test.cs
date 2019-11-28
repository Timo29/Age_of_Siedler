using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_test : MonoBehaviour
{
    public LayerMask destroy;
    Transform transform;
    Collider[] toDestroy;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < toDestroy.Length; i++)
            {
                Destroy(toDestroy[i].gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        toDestroy = Physics.OverlapSphere(transform.position, 5f, destroy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
