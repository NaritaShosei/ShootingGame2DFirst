using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float _maxLife;
    float _life;
    [SerializeField] Image _hpGauge;
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
        LifeGauge(currentLife);
        _life += currentLife;
    }
    void LifeGauge(float gauge)
    {
        float currentLife = _life;
        DOTween.To(() => currentLife / _maxLife, x => _hpGauge.fillAmount = x, (currentLife + gauge) / _maxLife, 0.3f);
    }
}
