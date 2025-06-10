using UnityEngine;

public class snailscript : MonoBehaviour
{
  float back;
    public float ehealth;
    Vector3 startpos;
    Vector3 currpos;
    Vector3 emove;
  public float eioframe;
    private RapierScript rapierScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        eioframe = 0;
        back = 0;
        ehealth = 100;
        startpos = transform.position;

        // Dynamically find and assign the RapierScript instance
        rapierScript = FindObjectOfType<RapierScript>();
        if (rapierScript == null)
        {
            Debug.LogError("RapierScript not found in the scene! Make sure it exists.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ehealth <= 0)
        {
            Destroy(gameObject);
        }

        eioframe -= 1;
        currpos = transform.position;

        // Check if rapierScript is null before accessing it
        if (rapierScript != null)
        {
            if (rapierScript.playerpos.x > currpos.x + 12 || rapierScript.playerpos.y > currpos.y + 12)
            {
                back = 1;
            }

            if (rapierScript.playerpos.x < currpos.x - 12 || rapierScript.playerpos.y < currpos.y - 12)
            {
                back = 1;
            }
        }
        else
        {
            Debug.LogWarning("rapierScript is null in snailscript!");
        }

        if (back == 1)
        {
            if (currpos.x > startpos.x)
            {
                emove = new Vector3(-1, 0, 0);
            }
            else
            {
                emove = new Vector3(1, 0, 0);
            }
        }

        transform.Translate(emove * Time.deltaTime);
    }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      back = 0;
      print(rapierScript.playerpos - currpos);
      if (rapierScript.playerpos.x > currpos.x)
      {
        emove = new Vector3(1, 0, 0);
      }
      else
      {
        emove = new Vector3(-1, 0, 0);
      }
    }
  }
  
    
}
