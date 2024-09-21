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
            Vector2 dir = (_lockOn.transform.position - transform.position).normalized;
            _rb.velocity = dir * _moveSpeed;
            transform.localRotation = Quaternion.LookRotation(Vector3.forward,dir);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
