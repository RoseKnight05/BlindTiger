using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int killCount = 0;  // Tracks how many enemies the player has killed
    public DoorController doorController;  // Reference to the DoorController script

    // Call this method whenever an enemy is killed
    public void IncrementKillCount()
    {
        killCount++;  // Increase kill count
        Debug.Log("KillCount incremented to: " + killCount);  // Debug log to track kills

        // Check if the player has killed 7 enemies
        if (killCount >= 7)
        {
            Debug.Log("7 enemies killed! Hiding the cube...");  // Debug log when 7 kills are reached
            if (doorController != null)
            {
                doorController.HideCube();  // Call the HideCube method to hide the door (Cube)
            }
            else
            {
                Debug.Log("DoorController is not assigned!");  // If no DoorController is assigned, log an error
            }
        }
    }
}
