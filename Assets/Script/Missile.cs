
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Missile : MonoBehaviour
{
    LockOn LockOn;
    Vector3 _velocity;
    Vector3 _position;
    GameObject _target;
    float _timer;
    [SerializeField] float _period = 1;//’…’e‚Ü‚Å‚ÌŽžŠÔ
    bool _isLockOn;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        LockOn = FindObjectOfType<LockOn>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vec = new Vector3(2, -1);
        _position = transform.position;
        _timer += Time.deltaTime;
        if (_timer <= 1f)
        {
            transform.position += vec * Time.deltaTime;
            if (LockOn.IsLockOn)
            {
                _target = LockOn._targetPosition[LockOn._targetCount];
                _isLockOn = true;
            }
            else
            {
                _isLockOn = false;
            }
        }
        if (_timer > 1f)
        {
            if (_isLockOn)
            {
                var acceleration = Vector3.zero;
                if (_target)
                {
                    var dir = _target.transform.position - _position;
                    transform.localRotation = Quaternion.LookRotation(transform.forward, dir);
                    acceleration += (dir - _velocity * _period) * 2f / (_period * _period);
                }
                else
                {
                    acceleration += (transform.forward) * 2f / (_period * _period);
                }
                _period -= Time.deltaTime;
                if (_period < 0)
                {
                    Destroy(gameObject);
                }
                _velocity += acceleration * Time.deltaTime;
                _position += _velocity * Time.deltaTime;
                transform.position = _position;
            }
            else
            {
                var acceleration = Vector3.zero;
                acceleration += (new Vector3(0, 5, 0) - _velocity * _period) * 2f / (_period * _period);

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
    }
}
