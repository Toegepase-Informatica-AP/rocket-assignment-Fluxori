using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && count == 0)
        {
            count++;
            if (SceneManager.GetActiveScene().name.Contains(Manager.maxGameLevel.ToString()) || SceneManager.GetActiveScene().name.Equals("Bonus_Level"))
            {
                Manager.gameLevel = 1;
                SceneManager.LoadScene("Finish");
            }
            else
            {
                SceneManager.LoadScene("Level" + ++Manager.gameLevel);
            }
        }
    }
}
