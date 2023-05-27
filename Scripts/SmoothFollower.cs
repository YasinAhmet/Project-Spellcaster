using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollower : MonoBehaviour
{

    public Transform followTarget;
    public Vector3 fixLoc;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        fixLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position + fixLoc, speed);
        }
    }
}
