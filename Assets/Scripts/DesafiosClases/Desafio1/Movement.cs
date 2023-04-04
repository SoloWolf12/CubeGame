using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    
    void Start()
    {
        transform.localScale = scale;
        
    }

    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
}
