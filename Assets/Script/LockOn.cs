using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweeng;

public class LockOn : MonoBehaviour
{
    List<GameObject> _targetPosition = new List<GameObject>();
    SpriteRenderer _sr;
    int _targetCount;
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _sr.enabled = true;
            var enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in enemy)
            {
                _targetPosition.Add(obj);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _targetCount = (_targetCount + 1) % _targetPosition.Count;
                transform.position = _targetPosition[_targetCount].transform.position;//‚±‚±DOMove‚Å‚â‚è‚½‚¢OnCompreat
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _targetCount--;
                if (_targetCount < 0)
                {
                    _targetCount = _targetPosition.Count - 1;
                }
                transform.position = _targetPosition[_targetCount].transform.position;
            }
        }

    }
}

