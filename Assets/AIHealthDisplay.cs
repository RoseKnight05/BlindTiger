using UnityEngine;
using UnityEngine.UI;  // For Text UI

public class AIHealthDisplay : MonoBehaviour
{
    public Text healthText;  // Reference to the Text component on the canvas
    public HealthComponent aiHealth;  // Reference to the AIHealth script (we’ll link it in the inspector)

    void Update()
    {
        // Update the text to show the current health
        if (aiHealth != null)
        {
            healthText.text = "Health: " + aiHealth.health.ToString("F0");
        }
    }
}
