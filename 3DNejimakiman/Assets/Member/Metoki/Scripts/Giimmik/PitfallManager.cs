using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallManager : MonoBehaviour
{
    public bool StopPlayer = false;
    private Rigidbody _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var moveCheck = collision.gameObject.GetComponent<PlayerMove>().Moveplayer;
            ////プレイヤーが停止していれば、FreezePositionY以外をオンにする
            if (!moveCheck)
            {
                _rb2d.constraints = RigidbodyConstraints.FreezePositionX;
                _rb2d.freezeRotation = true;
            }
        } 
    }
}
