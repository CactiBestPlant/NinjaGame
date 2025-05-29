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
        if (rapierScript.checkrapout == 0)
        {
            Destroy(gameObject);
        }
        if (rapierScript == null)
        {
            Debug.LogError("RapierScript is null!");
            return;
        }
    
        if (rapierScript.checkrapout == 0)
        {
            Debug.Log("Destroying GameObject because checkrapout is 0.");
            Destroy(gameObject);
            return;
        }
    
        if (target != null && rapierScript.weaponstop == 0)
        {
            transform.position = target.position + offset;
            Debug.Log($"Updated position: {transform.position}");
        }
        else if (target != null && rapierScript.weaponstop == 1)
        {
            // If weaponstop is 1, keep the rapier in its current position
            Debug.Log("Weaponstop is 1, keeping current position.");
        }
        else
        {
            Debug.LogWarning("Target is null or weaponstop is not valid.");
        }
        
    }
}
