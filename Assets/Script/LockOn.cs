using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LockOn : MonoBehaviour
{
    public List<GameObject> _targetPosition = new List<GameObject>();
    SpriteRenderer _sr;
    int _targetCount;
    bool _isComplete = true;
    float _distance;
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && _isComplete)
        {
            foreach (var targetPos in _targetPosition)
            {
                _distance = targetPos.transform.position.x - transform.position.x;
            }
            _isComplete = false;
            _sr.enabled = true;
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _targetCount = (_targetCount + 1) % _targetPosition.Count;
                //transform.position = _targetPosition[_targetCount].transform.position;
                transform.DOMove(_targetPosition[_targetCount].transform.position, 0.5f).OnComplete(() => _isComplete = true);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _targetCount--;
                if (_targetCount < 0)
                {
                    _targetCount = _targetPosition.Count - 1;
                }
                transform.DOMove(_targetPosition[_targetCount].transform.position, 0.5f).OnComplete(() => _isComplete = true);
            }
            Debug.Log("’·‚³" + _targetPosition.Count);
            Debug.Log("‚¢‚Ü" + _targetCount);
        }

    }
    public void Add(GameObject enemy)
    {
        _targetPosition.Add(enemy);
    }
    public void Remove(GameObject enemy)
    {
        _targetPosition.Remove(enemy);
    }
}

