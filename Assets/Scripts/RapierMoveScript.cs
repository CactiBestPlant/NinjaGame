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
            transform.Translate(rmove * Time.deltaTime * 5);
        }
        if (rappos.x < rapierScript.playerpos.x + 1)
        {
            rmove = new Vector3(1, 0, 0);
            transform.Translate(rmove * Time.deltaTime * 5);
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
}
