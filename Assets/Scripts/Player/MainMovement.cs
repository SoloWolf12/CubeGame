using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MainMovement : MonoBehaviour
{
    [SerializeField] private KeyCode fowardKey;
    [SerializeField] private KeyCode backwardKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private float speed;
    [SerializeField] private float travelTime;
    private bool isMoving = false;

    void Update()
    {
        CheckInputs();    
    }
    public void CheckInputs() 
    {
        if(Input.GetKeyDown(fowardKey) && !isMoving) 
        {
            StartCoroutine(MoveOverTime(Vector3.forward, travelTime));
        }
        if (Input.GetKeyDown(backwardKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.back, travelTime));
        }
        if (Input.GetKeyDown(leftKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.left, travelTime));
        }
        if (Input.GetKeyDown(rightKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.right, travelTime));
        }
    }
    private IEnumerator MoveOverTime(Vector3 direction, float duration)
    {
        float elapsedTime = 0f;
        isMoving = true;
        while (elapsedTime < duration)
        {
            transform.Translate(direction * (speed * Time.deltaTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
    }
}
