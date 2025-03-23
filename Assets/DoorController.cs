using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject cube;  // Reference to Cube (14) GameObject

    private bool isCubeVisible = true;  // Track if the cube is visible

    // Method to hide Cube (14)
    public void HideCube()
    {
        if (cube != null && isCubeVisible)
        {
            cube.SetActive(false);  // Disable the cube (make it disappear)
            isCubeVisible = false;  // Mark the cube as no longer visible
            Debug.Log("Cube (14) is now hidden!");
        }
    }
}
