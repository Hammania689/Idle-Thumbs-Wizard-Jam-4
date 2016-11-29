using UnityEngine;
using System.Collections;

public class TradeRouteScript : MonoBehaviour
{
    public int RouteType;
    public double value;
    public double risk;

    void Start()
    {
        RouteConverter();
    }
    
    // Use this for initialization
    void Update()
    {
        risk = value / ScoreManager.Score;
    }

    void RouteConverter()
    {
        switch (RouteType)
        {
            case 0: value = 47.5;
                break;
            case 1: value = 80;
                break;
            case 2: value = 90;
                break;
        }
    }
}
