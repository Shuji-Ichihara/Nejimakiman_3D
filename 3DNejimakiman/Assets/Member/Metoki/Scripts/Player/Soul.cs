using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soul : MonoBehaviour
{
    [SerializeField]
    Text text;
    GameObject _countSoul;
    public int SoulMax;
    private void Update()
    {
           _countSoul = GameObject.Find("Countsoul(Clone)");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("soul"))
        {
            SoulMax++;
            text.text = SoulMax + "";
            Destroy(_countSoul);
        }
    }
}
