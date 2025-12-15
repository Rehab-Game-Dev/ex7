using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject npcText; // Reference to the text object
    public float displayTime = 2f; // How long to show the text

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name + " with tag: " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Bumped into NPC - SUCCESS!");
            ShowText();
        }
    }

    void ShowText()
    {
        if (npcText != null)
        {
            npcText.SetActive(true); // Show the text
            Invoke("HideText", displayTime); // Hide it after 2 seconds
        }
    }

    void HideText()
    {
        if (npcText != null)
        {
            npcText.SetActive(false); // Hide the text
        }
    }
}