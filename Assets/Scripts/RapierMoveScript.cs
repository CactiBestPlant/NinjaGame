using UnityEngine;

public class RapierMoveScript : MonoBehaviour
{
    
    public Transform target;
    private Vector3 offset;
    RapierScript rapierScript;// Reference to the RapierScript instance

    void Awake()
    {
        if (target != null)
        {
            // Calculate the initial offset between the rapier and the player
            offset = transform.position - target.position + new Vector3(1, 0, 0);
        }
        else
        {
            Debug.LogError("Target (Player) is not assigned!");
        }

        // Find the RapierScript component on the same GameObject or another GameObject
        rapierScript = FindObjectOfType<RapierScript>();
    }

    void Update()
    {
        if (rapierScript != null && rapierScript.checkrapout == 0)
        {
            Destroy(gameObject);
        }
        if (target != null && transform.parent == null) // If not parented, update position manually
        {
            transform.position = target.position + offset;
        }
        if (rapierScript.checkrapout == 0)
        {
            Destroy(gameObject);
        }
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        
    }
}
