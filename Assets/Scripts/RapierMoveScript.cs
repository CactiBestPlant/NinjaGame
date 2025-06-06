using UnityEngine;

public class RapierMoveScript : MonoBehaviour
{

    Vector3 rappos;
    Vector3 rmove;
    RapierScript rapierScript;// Reference to the RapierScript instance

    void Awake()
    {
        rapierScript = FindObjectOfType<RapierScript>();
    }

    void Update()
    {
        Vector3 rappos = transform.position;
        if (rappos.x > rapierScript.playerpos.x + 1)
        {
            rmove = new Vector3(-1, 0, 0);
            transform.Translate(rmove * Time.deltaTime * 30);
        }
        if (rappos.x < rapierScript.playerpos.x + 1)
        {
            rmove = new Vector3(1, 0, 0);
            transform.Translate(rmove * Time.deltaTime * 30);
        }
        if (rapierScript.checkrapout == 0)
        {
            Destroy(gameObject);
        }
        if (rapierScript == null)
        {
            Debug.LogError("RapierScript is null!");
            return;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy")) // Access the collider property to check the tag
        {
            snailscript snail = other.collider.GetComponent<snailscript>(); // Access the collider to get the component
            if (snail != null)
            {
                snail.ehealth -= 50; // Adjust the damage value as needed
                snail.eioframe = 5; // Set the invincibility frame duration
                Debug.Log("Hit an enemy! Remaining health: " + snail.ehealth);
            }
        }
    }
}
