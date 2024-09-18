using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject[] _muzzle;
    [SerializeField] GameObject _missile;
    [SerializeField] GameObject _bullet;
    float _hMove;
    float _vMove;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _muzzle[0].transform.position, _bullet.transform.localRotation);
        }
        _hMove = Input.GetAxisRaw("Horizontal");
        _vMove = Input.GetAxisRaw("Vertical");
        var vel = _rb.velocity;
        vel.x = _hMove * _moveSpeed;
        vel.y = _vMove * _moveSpeed;
        _rb.velocity = vel;
    }
}
