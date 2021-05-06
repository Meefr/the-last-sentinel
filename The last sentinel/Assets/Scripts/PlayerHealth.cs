using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    private int health;
    public Text playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        playerHealth.text = health.ToString() + "%";
        playerHealth.color = Color.green;
        playerHealth.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(health <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(health > 50)
        {
            playerHealth.color = Color.green;
        }
        else
        {
            playerHealth.color = Color.red;
        }
        playerHealth.text = health.ToString() + "%";
        playerHealth.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet"))
        {
            health -= 2;
        }
        else if (other.CompareTag("Drone"))
        {
            health -= 20;
        }
        else if (other.CompareTag("Sword"))
        {
            health -= 5;
        }
    }
}
