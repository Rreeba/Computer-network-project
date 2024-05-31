using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Unitymanager : MonoBehaviour
{
    public Text inventoryText;

    void Start()
    {
        StartCoroutine(GetInventoryData());
    }

    IEnumerator GetInventoryData()
    {
        // URL of the PHP script
        string url = "http://localhost/unity/registerinventory.php";

        // Send request to PHP script
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error retrieving inventory data: " + www.error);
            }
            else
            {
                // Parse JSON data
                string inventoryData = www.downloadHandler.text;
                Debug.Log("Inventory Data: " + inventoryData);

                // Update UI with inventory data
                inventoryText.text = inventoryData;
            }
        }
    }
}