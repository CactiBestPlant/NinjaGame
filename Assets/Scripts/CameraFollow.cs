using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player GameObject
    public Vector3 offset;          // Offset between the camera and the player
    private Transform player;       // Cached reference to the player's transform

    void Start()
    {
        if (playerObject != null)
        {
            // Cache the player's transform
            player = playerObject.transform;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
    
    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to follow the player with the offset
            transform.position = player.position + offset;
        }
        else
        {
            Debug.LogWarning("Problem 4");
        }
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (playerObject != null)
        {
            // Cache the player's transform after the scene has loaded
            player = playerObject.transform;
        }
    }
}
