using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialViewer : MonoBehaviour
{
    public int isActiveLevel;
    private void OnEnable()
    {
        int level = PlayerPrefs.GetInt("LevelText",1);
        if (isActiveLevel>level)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
