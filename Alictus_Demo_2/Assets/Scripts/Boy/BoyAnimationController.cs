using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyAnimationController : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener( () => animator?.SetBool("isEnded", true) );
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener( () => animator?.SetBool("isEnded", true) );
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
