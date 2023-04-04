using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private int damage;

    void Update()
    {
        Shoot();        
    }

    public void Shoot() 
    {
        transform.position += direction*(speed*Time.deltaTime);
    }
}
