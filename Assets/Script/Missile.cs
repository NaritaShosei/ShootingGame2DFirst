using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    LockOn _target;
    Vector3 _velocity;
    Vector3 _position;
    [SerializeField] float _period = 1;//’…’e‚Ü‚Å‚ÌŽžŠÔ

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<LockOn>();
    }

    // Update is called once per frame
    void Update()
    {
        _position = transform.position;
        var dir = _target.transform.position - _position;
        transform.localRotation = Quaternion.LookRotation(transform.forward,dir);
        var acceleration = Vector3.zero;
        acceleration += (dir - _velocity * _period) * 2f / (_period * _period);

        _period -= Time.deltaTime;
        if (_period < 0)
        {
            Destroy(gameObject);
        }
        _velocity += acceleration * Time.deltaTime;
        _position += _velocity * Time.deltaTime;
        transform.position = _position;
    }
}
