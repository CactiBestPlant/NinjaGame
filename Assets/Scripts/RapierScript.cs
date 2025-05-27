using UnityEngine;

public class RapierScript : MonoBehaviour
{
    public float checkrapout;
    float rapinst;
    public GameObject rapier;
    float lungeDist;
    float lungeactive;
    public Vector3 playerpos;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkrapout = 0;
        lungeactive = 0; 
    }

    // Update is called once per frame
    void Update()
    {
       int rapinst = GameObject.FindGameObjectsWithTag("weapon").Length; // Correct method
        playerpos = transform.position;
        Vector3 movement = new Vector3(lungeDist, 0, 0);
        
       if (Input.GetMouseButton(0))
        {
            print("check rapier active");
            lungeDist += 1 * Time.deltaTime;
        }

       if(Input.GetMouseButtonUp(0))
       {
        print(lungeDist);
        if (lungeDist<=3)
        {
            lungeDist=2;
        }
        lungeactive=1;
       }

       if(lungeactive==1)
       {
        transform.Translate(movement*5*Time.deltaTime);
        lungeDist-=1*Time.deltaTime;
        if (lungeDist <= 0)
            {
                    lungeactive = 0;
            }
       }
       else
       {
        lungeDist=0;
       }
        if (Input.GetKey(KeyCode.E))
        {
            checkrapout = 1;
            if (rapinst < 1)
            {

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(rapier, playerpos, spawnRotation);
                //!!!!!!!!!!!!!set this as parent of rapier here!!!!!!!!!!!!!!!
            }
        }
        else
        {
            checkrapout = 0;
        }

       if (Input.GetKeyDown(KeyCode.E) && lungeDist < 1.5)
        {
            print("Check Stop");
            lungeactive = 0;
        }

    }

}
