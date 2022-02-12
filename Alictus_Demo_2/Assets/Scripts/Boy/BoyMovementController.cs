using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float decelerationRange;

    [SerializeField]
    private LayerMask layerMask;

    private Transform _transform;

    private bool isPlaying;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFinish.AddListener( () => isPlaying = false );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFinish.RemoveListener( () => isPlaying = false );
        EventManager.OnLevelFail.RemoveListener( () => isPlaying = false );
    }

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!isPlaying) return;

        RaycastHit hit;
        movementSpeed = Physics.Raycast(_transform.position, Vector3.forward, out hit, decelerationRange, layerMask) ? 2.5f : 5f;
        _transform.position += new Vector3(0f, 0f, movementSpeed * Time.deltaTime);
    }
}
