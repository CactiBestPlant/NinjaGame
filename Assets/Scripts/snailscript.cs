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
      back =0;
        rapierScript = FindObjectOfType<RapierScript>();
        ehealth = 100;
        startpos = transform.position;
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
      if (rapierScript != null)
      {
        Vector3 playerpos = rapierScript.playerpos;
      }  
      transform.Translate(emove * Time.deltaTime);

      if (rapierScript.playerpos.x > currpos.x + 12 || rapierScript.playerpos.y > currpos.y + 12)
      {
        back = 1;
      }

      if (rapierScript.playerpos.x < currpos.x - 12 || rapierScript.playerpos.y < currpos.y - 12)
      {
        back = 1;
      }

      if (back==1)
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
