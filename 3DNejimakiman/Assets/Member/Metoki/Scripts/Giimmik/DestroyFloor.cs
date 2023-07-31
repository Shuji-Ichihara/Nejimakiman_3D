using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloor : MonoBehaviour
{
    [SerializeField]
    GameObject hasi;
    [SerializeField]
    GameObject breakFloor;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasi.transform.Rotate(0, 0, 30);
            breakFloor.transform.Translate(0, 30, 0);
        }
    }
}
