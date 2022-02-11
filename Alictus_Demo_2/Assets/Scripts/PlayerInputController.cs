using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Camera mainCam;

    private GameObject selectedObject;

    private bool isPlaying;

    void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        isPlaying = true;       // todo delete after events are enabled
    }

    void Update()
    {
        DragObject();
    }

    private void DragObject()
    {
        if (!isPlaying) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();
                bool isTarget = hit.transform.gameObject.CompareTag("Target");

                if (!isTarget) return;

                Debug.Log(hit.transform.name);
                selectedObject = hit.transform.gameObject;
            }
        }
        else if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            selectedObject = null;
        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = mainCam.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, selectedObject.transform.position.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane);
        
        Vector3 worldMousePosFar = mainCam.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = mainCam.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);      // todo add layermask
        return hit;
    }
}
