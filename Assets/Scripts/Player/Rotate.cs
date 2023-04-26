using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class Rotate : MonoBehaviour
{  
    [SerializeField] MainMovement mainMovementScript;

    /*public IEnumerator RotateObject()
    {
        float timer = 0;    
        float timeToRotate = 0.2f; 
        Vector3 currentRotation = transform.eulerAngles;
        Vector3 targetRotation = currentRotation + new Vector3(90, 0, 0);
        Debug.Log("la rotacion actual es " + currentRotation + "y la deseada es " + targetRotation);

        
        while (timer < timeToRotate)
        {
            transform.eulerAngles = Vector3.Lerp(currentRotation, targetRotation, (timer / timeToRotate));
            timer += Time.deltaTime;
            yield return null;

           
        }
        transform.eulerAngles = targetRotation; 
    }*/   //consultar por que no anda

    public IEnumerator RotateObject(float degrees, Vector3 axis)
    {
        float timer = 0;
        float timeToRotate = mainMovementScript.travelTime;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = currentRotation * Quaternion.Euler(axis * degrees);
        Debug.Log("La rotación actual es " + currentRotation.eulerAngles + " y la deseada es " + targetRotation.eulerAngles);

        while (timer < timeToRotate)
        {
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, (timer / timeToRotate) * Quaternion.Angle(currentRotation, targetRotation));
            timer += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
    }
}
