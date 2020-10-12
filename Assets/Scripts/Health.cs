using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private const string LIVES_TEXT = "Lives: ";
    
    public GameObject livesText;
    
    public enum deathAction
    {
        loadLevelWhenDead,
        doNothingWhenDead
    };
    
    public float healthPoints = 1f;
    public float respawnHealthPoints = 3f; //base health points


    private int numberOfLives = 3; //lives and variables for respawning
    public int NumberOfLives
    {
        get => numberOfLives;
        set
        {
            numberOfLives = value; 
            ChangeLivesText(value);
        }
    }
    public bool isAlive = true;

    public GameObject explosionPrefab;

    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    public string LevelToLoad = "";

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;


    // Use this for initialization
    void Start()
    {
        // store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        if (LevelToLoad == "") // default to current scene 
        {
            LevelToLoad = SceneManager.GetActiveScene().name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            // if the object is 'dead'
            NumberOfLives--; // decrement # of lives, update lives GUI
            
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (numberOfLives > 0)
            {
                // respawn
                transform.position = respawnPosition; // reset the player to respawn position
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints; // give the player full health again
            }
            else
            {
                // here is where you do stuff once ALL lives are gone)
                isAlive = false;

                switch (onLivesGone)
                {
                    case deathAction.loadLevelWhenDead:
                        SceneManager.LoadScene(LevelToLoad);
                        break;
                    case deathAction.doNothingWhenDead:
                        // do nothing, death must be handled in another way elsewhere
                        break;
                }

                Destroy(gameObject);
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints -= amount;
    }

    public void ApplyHeal(float amount)
    {
        healthPoints += amount;
    }

    public void ApplyBonusLife(int amount)
    {
        NumberOfLives = NumberOfLives + amount;
    }

    public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }
    
    public  void ChangeLivesText(float lives)
    {
        livesText.GetComponent<TextMeshProUGUI>().text = LIVES_TEXT + lives;
    }
}