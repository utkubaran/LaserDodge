using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPredicter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float raycastDistance = 15f;

    [SerializeField]
    private LayerMask layerMask;

    private Transform _transform;

    void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLaserBeams();
    }

    private void CheckLaserBeams()
    {
        RaycastHit hit ;

        if (Physics.Raycast(_transform.position, Vector3.forward, out hit, raycastDistance))
        {
            if (!hit.transform.gameObject.CompareTag("Laser Light")) return;

            spriteRenderer.color = Color.red;
            Debug.Log("Obstacle");
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }

    private RaycastHit CastRay()
    {
        RaycastHit hit;
        Physics.Raycast(_transform.position, Vector3.forward, out hit, raycastDistance);
        return hit;
    }
}
