using UnityEngine;

public class RapierScript : MonoBehaviour
{
    float lungeDist;
    float lungeactive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lungeactive=0; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(lungeDist, 0, 0);
       if(Input.GetMouseButton(0))
       {
        print("check rapier active");
        lungeDist+=1*Time.deltaTime;
       }
       if(Input.GetMouseButtonUp(0))
       {
        print(lungeDist);
        lungeactive=1;
       }

       if(lungeactive==1)
       {
        transform.Translate(movement*5*Time.deltaTime);
        lungeDist-=1*Time.deltaTime;
        if(lungeDist<=0)
        {
            lungeactive=0;
        }
       }

    }

}
