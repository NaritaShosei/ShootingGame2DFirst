using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    LockOn _lockOn;
    // Start is called before the first frame update
    void Start()
    {
        _lockOn = FindObjectOfType<LockOn>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameVisible()
    {
        _lockOn.Add(gameObject);
    }
    private void OnBecameInvisible()
    {
        _lockOn.Remove(gameObject); 
    }
    private void OnDestroy()
    {
        _lockOn.Remove(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
