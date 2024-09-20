using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LockOn : MonoBehaviour
{
    public List<GameObject> _targetPosition = new List<GameObject>();
    SpriteRenderer _sr;
    public int _targetCount;
    bool _isComplete = true;
    float _distance;
    public bool IsLockOn;
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        IsLockOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && _isComplete)
        {
            if (_targetPosition.Count != 0)
            {
                IsLockOn = true;
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
                Debug.Log("IsLockOn" + IsLockOn);
            }
        }
        if (_targetPosition.Count == 0)
        {
            IsLockOn = false;
            _sr.enabled = false;
        }

    }
    public void Add(GameObject enemy)
    {
        _targetPosition.Add(enemy);
    }
    public void Remove(GameObject enemy)
    {
        _targetPosition.Remove(enemy);
        IsLockOn = false;
    }
    private void OnBecameInvisible()
    {
        _sr.enabled = false;
    }
}

