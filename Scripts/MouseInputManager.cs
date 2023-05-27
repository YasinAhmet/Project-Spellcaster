using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : DefPlayerRefs
{
    [SerializeField]
    LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RightClickEvent();
        }
    }

    public void RightClickEvent()
    {
        pc.movementRef.MoveInput();
    }

    public Vector3 lastMousePos = Vector3.zero;
    public Vector3 GetPosOfMouseInWorld()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            lastMousePos = hit.point;
            return hit.point;
        }

        lastMousePos = Vector3.zero;
        return Vector3.zero;
    }
}
