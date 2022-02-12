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

    void Update()
    {
        CheckLaserBeams();
    }

    /// <summary>
    /// Checks a specific distance for laser beams.
    /// If so, drag pointers' colors are changed upon raycast hit.
    /// </summary>
    private void CheckLaserBeams()
    {
        RaycastHit hit ;
        spriteRenderer.color = Physics.Raycast(_transform.position, Vector3.forward, out hit, raycastDistance, layerMask) ? Color.red : Color.green;
    }
}
