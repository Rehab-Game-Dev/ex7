using UnityEngine;
using TMPro;

public class NPCHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public TextMeshPro healthText; // Reference to the heart text

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("NPC Health: " + currentHealth);
        
        // Update hearts display
        UpdateHealthDisplay();
    }

    public void TakeDamage()
    {
        currentHealth--;
        Debug.Log("NPC hit! Health remaining: " + currentHealth);
        
        // Update hearts display
        UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            // Create string with hearts based on current health
            string hearts = "";
            for (int i = 0; i < currentHealth; i++)
            {
                hearts += "♥"; // Heart symbol
            }
            healthText.text = hearts;
        }
    }

    void Die()
    {
        Debug.Log("NPC is dead!");
        
        // Clear hearts
        if (healthText != null)
        {
            healthText.text = "";
        }
        
        // Make NPC invisible
        GetComponent<Renderer>().enabled = false;
        
        // Disable collider
        GetComponent<Collider>().enabled = false;
    }
}