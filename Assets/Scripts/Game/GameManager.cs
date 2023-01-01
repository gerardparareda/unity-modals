using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This could be a singleton but I don't have the time or energy
public class GameManager : MonoBehaviour
{

    public GameObject player;
    public void PauseGame()
    {
        Time.timeScale = 0;
        player.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        player.SetActive(true);
    }
}
