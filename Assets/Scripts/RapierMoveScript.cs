using UnityEngine;

public class RapierMoveScript : MonoBehaviour
{

    Vector3 rappos;
    Vector3 rmove;
    Vector3 yrmove;
    RapierScript rapierScript;// Reference to the RapierScript instance
    snailscript snail; // Reference to the snailscript instance
    float side;

    void Awake()
    {
        side = 1;
        rapierScript = FindObjectOfType<RapierScript>();
        snail = FindObjectOfType<snailscript>();
    }

    void Update()
    {
        Vector3 rappos = transform.position;
        if (rappos.x > rapierScript.playerpos.x + side)
        {
            rmove = new Vector3(-1, 0, 0);
            transform.Translate(rmove * Time.deltaTime * 30);
        }
        if (rappos.x < rapierScript.playerpos.x + side)
        {
            rmove = new Vector3(1, 0, 0);
            transform.Translate(rmove * Time.deltaTime * 30);
        }

         if (rappos.y > rapierScript.playerpos.y)
        {
            yrmove = new Vector3(0, -1, 0);
            transform.Translate(yrmove * Time.deltaTime * 30);
        }
        if (rappos.y < rapierScript.playerpos.y)
        {
            yrmove = new Vector3(0, 1, 0);
            transform.Translate(yrmove * Time.deltaTime * 30);
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

        if (rapierScript.Rappos == 1)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1; // Invert the x-axis scale
            transform.localScale = currentScale;
            side *= -1;
            rapierScript.Rappos = 0; // Reset the position flag
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && snail.eioframe<1) // Access the collider property to check the tag
        {
            if (snail != null)
            {
                snail.eioframe = 5;
                snail.ehealth -= 50; // Adjust the damage value as needed 
                Debug.Log("Hit an enemy! Remaining health: " + snail.ehealth);
            }
        }
    }
}
