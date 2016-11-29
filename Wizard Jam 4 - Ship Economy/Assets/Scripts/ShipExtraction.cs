using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipExtraction : MonoBehaviour
{
    DisplayText popUp;

    public bool isExtracting = false;
    public float extractionTime;
    public Text extrText;

    float initialTime, routeValue;

    public void AutoExtract(float routeVal)
    {
        routeValue = routeVal;
        extractionTime = routeVal / 10f;
        initialTime = extractionTime;
        isExtracting = true;
        Debug.Log(extractionTime);
    }

    void Update()
    {
        if (isExtracting)
        {
            extractionTime -= Mathf.Clamp(Time.deltaTime, 0f, extractionTime);
            Debug.Log(extractionTime);
            string seconds = extractionTime.ToString("f2");
            extrText.text = ("Extraction time: " + seconds);
            if (extractionTime == 0)
            {
                ScoreManager.Score += routeValue;
                extractionTime = initialTime;
            }
        }
    }

    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trade Route")
        {
            isExtracting = true;
            float routeVal = (float) col.GetComponent<TradeRouteScript>().value;
            extractionTime = routeVal / 10f;
            initialTime = extractionTime;
            routeValue = routeVal;
        }
    }

    void OnTriggerExit(Collider other)
    {
        extractionTime = 0f;
        isExtracting = false;
    }
}
