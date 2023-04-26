/*using System.Collections;
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
    [SerializeField] [Tooltip("9")] public float speed;
    [SerializeField] [Tooltip("0.2")] public float travelTime;
    public bool isMoving = false;
    [SerializeField] Rotate rotateCubeScript;

    void Update()
    {
        CheckInputs();    
    }
    public void CheckInputs() 
    {
        if(Input.GetKeyDown(fowardKey) && !isMoving) 
        {
            StartCoroutine(MoveOverTime(Vector3.forward, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, Vector3.right));

        }   
        if (Input.GetKeyDown(backwardKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.back, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, Vector3.left));
        }
        if (Input.GetKeyDown(leftKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.left, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, Vector3.forward));
        }
        if (Input.GetKeyDown(rightKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.right, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, Vector3.back));
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
}*/

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
    [SerializeField][Tooltip("9")] public float speed;
    [SerializeField][Tooltip("0.2")] public float travelTime;
    public bool isMoving = false;
    [SerializeField] Rotate rotateCubeScript;
    void Update()
    {
        CheckInputs();
        if (Input.GetKeyDown("space"))
        {
            Debug.Log($"Right: {WhatIsRight()} // Forward: {WhatIsForward()}");
        }
    }
    private Vector3 WhatIsForward()
    {
        Vector3 forwardAxis = transform.GetChild(0).TransformDirection(Vector3.forward);
        Vector3 upAxis = transform.GetChild(0).TransformDirection(Vector3.up);
        Vector3 rightAxis = transform.GetChild(0).TransformDirection(Vector3.right);

        if (Mathf.Abs(Vector3.Dot(forwardAxis, Vector3.forward)) > 0.9f)
        {
            return new Vector3(0, 0, Vector3.Dot(forwardAxis, Vector3.forward));
        }
        else if (Mathf.Abs(Vector3.Dot(upAxis, Vector3.forward)) > 0.9f)
        {
            return new Vector3(0, Vector3.Dot(upAxis, Vector3.forward), 0);
        }
        else if (Mathf.Abs(Vector3.Dot(rightAxis, Vector3.forward)) > 0.9f)
        {
            return new Vector3(Vector3.Dot(rightAxis, Vector3.forward), 0, 0);
        }
        else
        {
            return Vector3.zero;
        }
    }
    private Vector3 WhatIsRight()
    {
        Vector3 forwardAxis = transform.GetChild(0).TransformDirection(Vector3.forward);
        Vector3 upAxis = transform.GetChild(0).TransformDirection(Vector3.up);
        Vector3 rightAxis = transform.GetChild(0).TransformDirection(Vector3.right);

        if (Mathf.Abs(Vector3.Dot(forwardAxis, Vector3.right)) > 0.9f)
        {
            return new Vector3(0, 0, Vector3.Dot(forwardAxis, Vector3.right));
        }
        else if (Mathf.Abs(Vector3.Dot(upAxis, Vector3.right)) > 0.9f)
        {
            return new Vector3(0, Vector3.Dot(upAxis, Vector3.right), 0);
        }
        else if (Mathf.Abs(Vector3.Dot(rightAxis, Vector3.right)) > 0.9f)
        {
            return new Vector3(Vector3.Dot(rightAxis, Vector3.right), 0, 0);
        }
        else
        {
            return Vector3.zero;
        }
    }
    public void CheckInputs()
    {
        if (Input.GetKeyDown(fowardKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.forward, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, WhatIsRight()));

        }
        if (Input.GetKeyDown(backwardKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.back, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, -WhatIsRight()));
        }
        if (Input.GetKeyDown(leftKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.left, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, WhatIsForward()));
        }
        if (Input.GetKeyDown(rightKey) && !isMoving)
        {
            StartCoroutine(MoveOverTime(Vector3.right, travelTime));
            StartCoroutine(rotateCubeScript.RotateObject(90f, -WhatIsForward()));
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

