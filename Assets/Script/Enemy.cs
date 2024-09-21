using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    LockOn _lockOn;
    HealthSystem _healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        _lockOn = FindObjectOfType<LockOn>();   
        _healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameVisible()
    {
        Debug.Log("Camera In");
        _lockOn.Add(gameObject);
    }
    private void OnBecameInvisible()
    {
        Debug.Log("Camera Out");
        _lockOn.Remove(gameObject); 
    }
    private void OnDestroy()
    {
        Debug.Log("Destroy");
        _lockOn.Remove(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _healthSystem.Life(-1);
        }
    }
}
