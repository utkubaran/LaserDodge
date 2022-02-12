using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    void Start()
    {
        levelText.text = "LEVEL " + (LevelManager.instance.CurrentSceneIndex + 1).ToString();
    }
}
