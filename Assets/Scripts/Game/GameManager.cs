using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This could be a singleton but I don't have the time or energy
public class GameManager : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
