using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float _maxLife;
    float _life;
    // Start is called before the first frame update
    void Start()
    {
        _life = _maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (_life <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Life(float currentLife)
    {
        _life += currentLife;
    }
    void LifeGauge(float gauge)
    {

    }
}
