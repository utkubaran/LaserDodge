using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Boy : MonoBehaviour
{
    private RigBuilder rigBuilder;

    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener( () => rigBuilder.enabled = false );
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener( () => rigBuilder.enabled = false ); 
    }

    void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
    }

}
