using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class ProgressManager
{
    private static int _currentStage = 0;

    public static int currentStage => _currentStage;

    public static void setCurrentStage(int i)
    {
        _currentStage = i;
    }

    public static void increaseCurrentStage(int i = 1)
    {
        _currentStage += i;
    }

    public static void resetProgress()
    {
        setCurrentStage(0);
    }

    public static void toStageSelect()
    {
        SceneManager.LoadScene("AuStageSelect");
    }

    public static void toBattle()
    {
        SceneManager.LoadScene("AuBattle");
    }
}
