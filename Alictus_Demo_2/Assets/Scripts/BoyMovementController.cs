using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Transform _transform;

    private bool isPlaying;

    private void Awake()
    {
        _transform = transform;
    }

    void Start()
    {
        isPlaying = true;           // todo delete after events are enabled
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _transform.position += new Vector3(0f, 0f, movementSpeed * Time.deltaTime);
    }
}
