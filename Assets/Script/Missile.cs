using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    LockOn _target;
    Vector3 _velocity;
    Vector3 _position;
    float _timer;
    [SerializeField] float _period = 1;//���e�܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<LockOn>();
    }

    // Update is called once per frame
    void Update()
    {
        _position = transform.position;
        _timer += Time.deltaTime;
        if (_timer <= 0.5f)
        {

            transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
        }
        if (_timer > 0.5f)
        {
            if (_target.IsLockOn)
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
