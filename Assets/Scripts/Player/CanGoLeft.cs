using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanGoLeft : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float _raycastDistance = 10f;


    public bool CanMove()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance, layerMask))
        {
            Debug.Log("puedes seguir");
            return true;
        }
        else
        {
            Debug.Log("no puedes avanzar");
            return false;
        }
    }
}
