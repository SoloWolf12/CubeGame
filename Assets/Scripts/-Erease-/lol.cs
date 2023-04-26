using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lol : MonoBehaviour
{
    
       // [SerializeField] private float rotationSpeed = 90f;

        private Quaternion startRotation;
        private Quaternion endRotation;
        private float elapsedTime;

        private void Start()
        {
            startRotation = transform.rotation;
            endRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            elapsedTime = 0f;
        }

        private void Update()
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 1f); // 1 second rotation time
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
        }

        
    
}
