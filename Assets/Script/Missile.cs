using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    LockOn LockOn;
    Vector3 _velocity;
    Vector3 _position;
    GameObject _target;
    float _timer;
    [SerializeField] float _period = 1;//’…’e‚Ü‚Å‚ÌŽžŠÔ

    // Start is called before the first frame update
    void Start()
    {
        LockOn = FindObjectOfType<LockOn>();

    }

    // Update is called once per frame
    void Update()
    {
        var vec = new Vector3(2 * Time.deltaTime, 1);
        _position = transform.position;
        _timer += Time.deltaTime;
        if (_timer <= 1f)
        {
            transform.position -= new Vector3(1, -(transform.position.x * transform.position.x) * Time.deltaTime, 0).normalized * Time.deltaTime * 2 + vec * Time.deltaTime;

            if (LockOn.IsLockOn)
            {
                _target = LockOn._targetPosition[LockOn._targetCount];
            }
        }
        if (_timer > 1f)
        {
            if (LockOn.IsLockOn)
            {
                var dir = _target.transform.position - _position;
                transform.localRotation = Quaternion.LookRotation(transform.forward, dir);
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
