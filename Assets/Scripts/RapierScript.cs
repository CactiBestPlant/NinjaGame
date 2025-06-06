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
    public float weaponstop;
    float stopstop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponstop = 0;
        checkrapout = 0;
        lungeactive = 0;
        stopstop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int rapinst = GameObject.FindGameObjectsWithTag("weapon").Length; // Correct method
        playerpos = transform.position;
        Vector3 movement = new Vector3(lungeDist, 0, 0);

        if (Input.GetMouseButton(0))
        {
            lungeDist += 1 * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            print(lungeDist);
            if (lungeDist <= 3)
            {
                lungeDist = 2;
            }
            lungeactive = 1;
        }

        if (lungeactive == 1)
        {
            transform.Translate(movement * 5 * Time.deltaTime);
            lungeDist -= 1 * Time.deltaTime;
            if (lungeDist <= 0)
            {
                lungeactive = 0;
            }
        }
        else
        {
            lungeDist = 0;
        }
        if (Input.GetKey(KeyCode.V))
        {
            checkrapout = 1;
            if (rapinst < 1)
            {

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(rapier, playerpos, spawnRotation);
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

        if (stopstop == 1)
        {
            weaponstop = 0;
            stopstop = 0;
        }

        if (Input.GetKeyDown(KeyCode.F)) // Replace 'F' with your desired button
        {
            // Flip the player's scale along the x-axis
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1; // Invert the x-axis scale
            transform.localScale = currentScale;
        }
    }
}
