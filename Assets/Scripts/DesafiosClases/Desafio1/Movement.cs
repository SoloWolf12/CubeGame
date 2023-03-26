using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] public GameObject lol;
    void Start()
    {
        transform.localScale = scale;
        Debug.Assert(1 < 0, "obvio",lol);
        Debug.LogError("sdff");
    }

    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
}
