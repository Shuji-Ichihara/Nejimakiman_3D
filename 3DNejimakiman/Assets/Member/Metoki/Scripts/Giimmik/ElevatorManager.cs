using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _top;
    private float _under;
    private Vector2 _elevatorPosition;
    private Rigidbody rb;
    private bool _first = true;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        _under = this.transform.position.y;//下(スタート地点)
    }

    private void FixedUpdate()
    {
        _elevatorPosition = this.transform.position;//現在の位置

        if (_first) rb.velocity = new Vector2(0, _speed * 1f);//上
        else rb.velocity = new Vector2(0, _speed * -1f);//下

        //切り替え
        if (_elevatorPosition.y >= _top) _first = false;
        else if (_elevatorPosition.y <= _under) _first = true;
    }
}
