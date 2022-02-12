using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyAnimationController : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener(PlayDanceAnimation);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener(PlayDanceAnimation);
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void PlayDanceAnimation()
    {
        animator?.SetBool("isEnded", true);
    }
}
