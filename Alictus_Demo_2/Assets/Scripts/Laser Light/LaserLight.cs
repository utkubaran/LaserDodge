using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isBodyPart = other.gameObject.CompareTag("Body Part");

        if (!isBodyPart) return;

        EventManager.OnLevelFail?.Invoke();
    }
}
