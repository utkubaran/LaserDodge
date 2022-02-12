using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Boy : MonoBehaviour
{
    private RigBuilder rigBuilder;

    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener(DisableRigBuilder);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener(DisableRigBuilder); 
    }

    void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
    }

    // Disables rig builder to play animation
    private void DisableRigBuilder()
    {
        rigBuilder.enabled = false;
    }

}
