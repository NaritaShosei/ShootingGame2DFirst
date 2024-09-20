using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    Rigidbody2D _rb;
    LockOn _lockOn;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lockOn = FindObjectOfType<LockOn>();
        if (!_lockOn.IsLockOn)
        {
            _rb.velocity = Vector2.up * _moveSpeed;
        }
        else if (_lockOn.IsLockOn)
        {
            _rb.velocity =(_lockOn.transform.position - transform.position).normalized * _moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
