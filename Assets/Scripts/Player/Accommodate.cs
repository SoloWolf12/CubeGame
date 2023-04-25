using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accommodate : MonoBehaviour
{
    private LayerMask _layerMask; 
    private float _raycastDistance = 1f; 
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit; 
        if (Physics.Raycast(ray, out hit, _raycastDistance, _layerMask))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            Debug.Log("Acomodando");
        }
    }
}
