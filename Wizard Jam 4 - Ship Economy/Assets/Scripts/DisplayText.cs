using UnityEngine;
using System.Collections;

public class DisplayText : MonoBehaviour
{
    public GameObject TextHolder;

    void OnTriggerEnter()
    {
        TextHolder.SetActive(true);
    }

    public void ClearMessage()
    {
        TextHolder.SetActive(false);
    }
}
