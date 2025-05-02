using UnityEngine;
using TMPro;

public class armourscript : MonoBehaviour
{
    float TMParmourinst;
    public float armour;
    private TextMeshProUGUI armourText;

    void Start()
    {
        armour = 0;

        // Dynamically create a new GameObject for the TextMeshPro UI
        GameObject textObject = new GameObject("ArmourText");
        textObject.transform.SetParent(GameObject.Find("Canvas").transform); // Attach to Canvas

        // Add TextMeshProUGUI component to the new GameObject
        armourText = textObject.AddComponent<TextMeshProUGUI>();

        // Configure the TextMeshPro properties
        armourText.fontSize = 18;
        armourText.alignment = TextAlignmentOptions.Center;
        armourText.rectTransform.sizeDelta = new Vector2(300, 100); // Set size
        armourText.rectTransform.anchorMin = new Vector2(0, 1);
        armourText.rectTransform.anchorMax = new Vector2(0, 1);
        armourText.rectTransform.anchoredPosition = new Vector2(50, -50); // 50 units right and 50 units down from the top-left

        UpdateArmourText();
    }

    void Update()
    {
        // Constantly check how many TextMeshProUGUI objects exist
        int textMeshProCount = FindObjectsOfType<TextMeshProUGUI>().Length;
        if (TMParmourinst > 1)
        {
        Debug.Log("Number of TextMeshProUGUI objects: " + textMeshProCount);
        }
        TMParmourinst = textMeshProCount;
        if (TMParmourinst > 1)
        {
            TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();
            for (int i = 1; i < textObjects.Length; i++)
            {
                Destroy(textObjects[i].gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            armour += 1; // Update the armour variable
            UpdateArmourText(); // Update the TextMeshPro text to reflect the new armour value
            Debug.Log("Armour: " + armour);
        }
    }
    
    void UpdateArmourText()
    {
        armourText.text = "Armour: " + armour; // Update the TextMeshProUGUI text
    }
}

