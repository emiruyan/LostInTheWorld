using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using LostInTheWorld.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonThisObject<LevelManager>
{
    public List<Level> levels;
    public Level currentLevel;
    public const string LevelKey = "Level";
    public const string LevelTextKey = "LevelText";
    [SerializeField] private TextMeshProUGUI levelText;
    private int level=0;
    private int levelTextValue=0;
    private void Awake()
    {
        SingletonThisGameObject(this);
    }

    public void Start()
    {
        level = PlayerPrefs.GetInt(LevelKey, 0);
        levelTextValue = PlayerPrefs.GetInt(LevelTextKey, 1);
        levelText.text = "Level "+levelTextValue;
        LevelInstantiate();
    }

    private void LevelInstantiate()
    {
        if (level >= levels.Count)
        {
            level = 1;
            PlayerPrefs.SetInt(LevelKey,1);
            LevelInstantiate();
        }
        else
        {
            currentLevel = Instantiate(levels[level], levels[level].transform.position, levels[level].transform.rotation);
            GameManager.Instance.Character._fireParticleEffect.SetMaxFire(currentLevel.maxFire);
        }
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt(LevelTextKey, levelTextValue+1);
        PlayerPrefs.SetInt(LevelKey,level+1);
    }
}
