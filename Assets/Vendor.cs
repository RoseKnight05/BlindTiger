using UnityEngine;

public class Vendor : MonoBehaviour
{
    public GameObject shopUI; // Assign your UI panel in the Inspector

    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // Press E to interact
        {
            ToggleShop();
        }
    }

    void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf); // Show/hide shop UI
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            shopUI.SetActive(false); // Close UI when player leaves
        }
    }
}