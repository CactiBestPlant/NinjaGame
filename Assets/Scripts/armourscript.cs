using UnityEngine;
using TMPro;

public class armourscript : MonoBehaviour
{
    public float armour; // Player's armour value
    private TextMeshProUGUI armourText;
    private int TMParmourinst;

    void Start()
    {
        armour = 0;

        // Check if a TextMeshProUGUI instance already exists
        TMParmourinst = FindObjectsOfType<TextMeshProUGUI>().Length;
        if (TMParmourinst == 0)
        {
            // Create a new TextMeshProUGUI object if none exists
            GameObject textObject = new GameObject("ArmourText");
            textObject.transform.SetParent(GameObject.Find("Canvas").transform); // Attach to Canvas

            armourText = textObject.AddComponent<TextMeshProUGUI>();
            armourText.fontSize = 18;
            armourText.alignment = TextAlignmentOptions.Center;
            armourText.rectTransform.sizeDelta = new Vector2(300, 100);
            armourText.rectTransform.anchorMin = new Vector2(0, 1);
            armourText.rectTransform.anchorMax = new Vector2(0, 1);
            armourText.rectTransform.anchoredPosition = new Vector2(50, -50);

            UpdateArmourText();
        }
        else
        {
            // If a TextMeshProUGUI instance exists, use it
            armourText = FindObjectOfType<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        // Constantly check how many TextMeshProUGUI objects exist
        int textMeshProCount = FindObjectsOfType<TextMeshProUGUI>().Length;
        if (textMeshProCount > 1)
        {
            Debug.Log("Number of TextMeshProUGUI objects: " + textMeshProCount);

            // Destroy extra TextMeshProUGUI objects, keeping only the first one
            TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();
            for (int i = 1; i < textObjects.Length; i++)
            {
                Destroy(textObjects[i].gameObject);
            }
        }
        TMParmourinst = textMeshProCount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject); // Destroy the armour pickup
            armour += 1; // Increment the armour variable
            UpdateArmourText(); // Update the TextMeshPro text
            Debug.Log("Armour: " + armour);
        }
    }

    void UpdateArmourText()
    {
        if (armourText != null)
        {
            armourText.text = "Armour: " + armour; // Update the TextMeshProUGUI text
        }
    }
}
