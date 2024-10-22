using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PropertyManager : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public TMP_Text m_title;
    public Button m_buyHouseOrHotelButton;
    public TMP_Text m_buyHouseOrHotelButtonText;
    public Button m_sellHouseOrHotelButton;
    public TMP_Text m_sellHouseOrHotelButtonText;
    public Button m_mortgageButton;
    public TMP_Text m_mortgageButtonText;
    public Button m_backButton;
    public TMP_Text m_description;
    public GameObject m_window;
    public Scrollbar m_scrollbar;

    // ======================================== Private Data Members ======================================= //
    public Controller_Game m_gameController;

    // ======================================== Start / Update ============================================= //
    void Start()
    {
        m_window.SetActive(false);
        m_backButton.onClick.AddListener(ClosePropertyManger);
    }

    // ======================================== Public Methods ============================================= //

    public void CreatePropertyManager(string a_propertyName, string a_propertyDescription, 
        int a_mortgageValue, int a_houseCost, bool a_buyHouseAvailible, bool a_sellHouseAvailible, 
        bool a_buyHotelAvailible, bool a_sellHotelAvailible, bool a_mortgageAvailible,
        bool a_unmortgageAvailible, int a_propertyIndex)
    {
        // Add all listeners
        m_buyHouseOrHotelButton.onClick.AddListener(() => m_gameController.PropertyManager_BuyHouse(a_propertyIndex));
        m_sellHouseOrHotelButton.onClick.AddListener(() => m_gameController.PropertyManager_SellHouse(a_propertyIndex));

        // Reset scrollbar
        m_scrollbar.value = 0f;

        // Set text of titles
        m_title.text = a_propertyName;
        m_description.text = a_propertyDescription;

        // Buying 
        m_buyHouseOrHotelButton.interactable = true;
        if (a_buyHouseAvailible)
            m_buyHouseOrHotelButtonText.text = "Buy\nHouse\n($-" + a_houseCost + ")";

        else if (a_buyHotelAvailible)
            m_buyHouseOrHotelButtonText.text = "Buy\nHotel\n($-" + a_houseCost + ")";

        else
        {
            m_buyHouseOrHotelButtonText.text = "Buying Unavailible";
            m_buyHouseOrHotelButton.interactable = false;
        }

        // Selling
        m_sellHouseOrHotelButton.interactable = true;   
        if (a_sellHouseAvailible)
            m_sellHouseOrHotelButtonText.text = "Sell\nHouse\n($+" + a_houseCost / 2 + ")";
        else if (a_sellHotelAvailible)
            m_sellHouseOrHotelButtonText.text = "Sell\nHotel\n($+" + a_houseCost / 2+ ")";

        else
        {
            m_sellHouseOrHotelButtonText.text = "Selling unavailible";
            m_sellHouseOrHotelButton.interactable = false;
        }

        // Mortgage
        if (a_mortgageAvailible)
        {
            m_mortgageButtonText.text = "Mortgage\n(+$" + a_mortgageValue + ")";
            m_mortgageButton.onClick.AddListener(() => m_gameController.PropertyManager_MortgageProperty(a_propertyIndex));
            m_mortgageButton.interactable = true;
        }
        else if (a_unmortgageAvailible)
        {
            m_mortgageButtonText.text = "Buy back\n(-$" + a_mortgageValue + ")";
            m_mortgageButton.onClick.AddListener(() => m_gameController.PropertyManager_UnmortgageProperty(a_propertyIndex));
            m_mortgageButton.interactable = true;
        }
        else
        {
            m_mortgageButtonText.text = "Mortgaging Unavailible";
            m_mortgageButton.interactable = false;
        }

        // Activate the window
        m_window.SetActive(true);
    }

    // Closes property window
    public void ClosePropertyManger() { m_window.SetActive(false); }

    // Resets button listenerns on all the buttons
    public void ResetWindow()
    {
        m_buyHouseOrHotelButton.onClick.RemoveAllListeners();
        m_sellHouseOrHotelButton.onClick.RemoveAllListeners();
        m_mortgageButton.onClick.RemoveAllListeners();
    }
}
