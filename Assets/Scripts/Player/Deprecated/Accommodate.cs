using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accommodate : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; 
    [SerializeField] private float _raycastDistance = 10f; 
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit; 
        if (Physics.Raycast(ray, out hit, _raycastDistance, layerMask))
        {
            //Debug.Log("Acomodando en posición " + hit.transform.parent.position);
            Vector3 parentPos = hit.transform.parent.position;
            hit.transform.parent.localPosition= parentPos;
            Debug.Log(parentPos);

            Debug.DrawLine(transform.position, hit.point, Color.green);
        }

        Vector3 myPosition = transform.position;
        Debug.Log("Mi posición: " + myPosition);
    }
}
