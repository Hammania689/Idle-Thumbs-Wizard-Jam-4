using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public DisplayText message;

    public static bool TradeRouteMenu;
    public static double Score;
    public GameObject pirate,tradeRoutes;
    public Canvas RouteMenu;
    public Button changeRouteButton;

    GameObject player;
    Text text;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = this.GetComponent<Text>();
        text.text = "Resources: " + Score;
        TradeRouteMenu = false;
    }

    // Update is called once per frame
    void Update ()
    {
        text.text = "Resources: " + Score;
        if(Score >= 100)
            pirate.SetActive(true);
        RouteSelect();
	}

    void RouteSelect()
    {
        if ((Score >= 90) && (TradeRouteMenu == false))
        {
            TradeRouteMenu = true;
            RouteMenu.gameObject.SetActive(true);
            message.gameObject.SetActive(true);
            tradeRoutes.SetActive(false);
        }
    }

    public void RouteSelected()
    {
        RouteMenu.gameObject.SetActive(false);
        message.gameObject.SetActive(false);
        changeRouteButton.gameObject.SetActive(true);
    }

    public void ChangeRoute()
    {
        RouteMenu.gameObject.SetActive(true);
        message.gameObject.SetActive(true);
    }
}
