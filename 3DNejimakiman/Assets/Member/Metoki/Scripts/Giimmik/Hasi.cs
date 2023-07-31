using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hasi : MonoBehaviour
{
    [SerializeField]
    GameObject hasi;
    [SerializeField]
    GameObject breakFloor;
    [SerializeField]
    GameObject destroyFloor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) 
        { 
            hasi.transform.Rotate(0, 0, 30);
            breakFloor.transform.Translate(0, 30, 0);
            destroyFloor.transform.Translate(0, 30, 0);
        }
    }
}
