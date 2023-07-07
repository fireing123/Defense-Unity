using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiseLevel : MonoBehaviour
{
    public void LevelScene(string levelName)
    {
        try
        {
            SceneManager.LoadScene(levelName);
        } catch (Exception e)
        {
            Debug.LogError(e);
        }
        
    }
}
