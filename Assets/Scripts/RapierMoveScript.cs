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
            offset = transform.position - target.position+ new Vector3(1, 0, 0);
        }

        // Find the RapierScript component on the same GameObject or another GameObject
        rapierScript = FindObjectOfType<RapierScript>();
        if (rapierScript == null)
        {
            Debug.LogError("RapierScript instance not found!");
        }
    }

    void Update()
    {
        if (rapierScript.checkrapout == 0)
        {
            Destroy(gameObject);
        }
        if (rapierScript != null)
        {
            transform.position = Vector3.Lerp( transform.position, target.position + offset, Time.deltaTime * 15f);
        }
    }
}
