using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelLoad : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        if (scene.Any(char.IsDigit))
        {
            string number = Regex.Match(scene, @"\d+").Value;
            Manager.gameLevel = int.Parse(number);
        }
        SceneManager.LoadScene(scene);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
