using UnityEngine;

public class snailscript : MonoBehaviour
{
    float ehealth;
    Vector3 startpos;
    Vector3 currpos;
    Vector3 emove;
    private RapierScript rapierScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rapierScript = FindObjectOfType<RapierScript>();
        ehealth = 100;
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currpos = transform.position;
      if (rapierScript != null)
      {
        Vector3 playerpos = rapierScript.playerpos;
      }  
      transform.Translate(emove * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("check trigger");
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
