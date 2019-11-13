using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public List<int> playerHashes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "resident")
        {
            for (int i = 0; i < playerHashes.Count; i++)
            {
                if(playerHashes[i] == other.gameObject.GetHashCode())
                {
                    Debug.Log("isMining");
                    other.gameObject.GetComponent<Animator>().SetBool("isMining", true);
                }
            }
        }
    }
    
}
