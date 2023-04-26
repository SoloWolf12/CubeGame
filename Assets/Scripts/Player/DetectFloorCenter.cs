using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFloorCenter : MonoBehaviour
{
    public Vector3 floorPosition;
    [SerializeField] private float speed;
    [SerializeField] MainMovement mainMovementScript;

    
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.transform.localPosition);        
        //floorPosition = collision.transform.localPosition;
        floorPosition = new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z);
        var distancia=transform.localPosition - floorPosition;
        float magnitudDistancia=distancia.magnitude;
        
        if (magnitudDistancia <= 0.01 && !mainMovementScript.isMoving)
        {
            transform.position = floorPosition;
        }
        if (floorPosition != transform.position && !mainMovementScript.isMoving)
        {
            // transform.position = floorPosition;

            transform.position = Vector3.MoveTowards(transform.position, floorPosition, speed * Time.deltaTime);
        }
    }

}
/*private Vector3 originalPos;
Vector3 distancia = transform.position - originalPos;
float magnitudDistancia = distancia.magnitude;
if (magnitudDistancia <= 0.01)
{
    transform.position = originalPos;
}
if (originalPos != transform.position)
{
    transform.position += speed * Time.deltaTime;
}*/

