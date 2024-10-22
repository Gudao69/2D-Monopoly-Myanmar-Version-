using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Trading : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public Controller_Game m_gameController;
    public GameObject m_tradingMenu;
    public TMP_Text m_tradingPlayerTitle;
    public Image m_tradingPlayerIcon;
    public Button m_sendButton;
    public Button m_doneButton;
    public TMP_Dropdown m_propertyDropdown;
    public TMP_InputField m_cashInput;

    // ======================================== Private Data Members ======================================= //
    int m_availibleCash;
    string m_playerName;

    // ======================================== Start / Update ============================================= //
    void Start()
    {
        // Add listeners
        m_sendButton.onClick.AddListener(SendToGame);
        m_doneButton.onClick.AddListener(OnDoneClick);
        m_cashInput.onValueChanged.AddListener(OnCashInput);

        // Close the menu on start
        m_tradingMenu.SetActive(false);
    }

    // ======================================== Public Methods ============================================= //
    
    public void CreateTradingMenu(string a_name, Sprite a_icon, List<string> a_propertiesAndCards, int a_availibleCash)
    {
        // Clear cash input
        m_cashInput.text = "";
        m_sendButton.interactable = true;

        // Reset the property dropdown
        m_propertyDropdown.ClearOptions();

        // Set title and icon
        m_tradingPlayerTitle.text = "Trading with: " + a_name;
        m_tradingPlayerIcon.sprite = a_icon;

        // Set current cash
        m_availibleCash = a_availibleCash;

        // Set current player's name
        m_playerName = a_name;

        // Fill the dropdown with property names
        a_propertiesAndCards.Insert(0, "Select Property / Card");
        m_propertyDropdown.AddOptions(a_propertiesAndCards);

        // Set window as active
        m_tradingMenu.SetActive(true);
    }
    /* public void CreateTradingMenu(string a_name, Sprite a_icon, List<string> a_propertiesAndCards, int a_availibleCash) */

    // Closes the trading menu
    public void CloseTradingMenu()
    {
        m_tradingMenu.SetActive(false);
    }

    // ======================================== Private Methods ========================================== //

    void SendToGame()
    {
        // Obtain the selected property
        string selectedOptionDefault = "Select Property / Card";
        string selectedOption = m_propertyDropdown.options[m_propertyDropdown.value].text;
        int inputCash = 0;
        int.TryParse(m_cashInput.text, out inputCash);

        // Don't send to controller, nothing entered
        if (selectedOption == selectedOptionDefault && inputCash == 0)
            return;

        // Send to controller if property or card entered
        if (selectedOption != selectedOptionDefault)
        {
            // Card traded
            if (selectedOption == "Community Chest Jail Card" || selectedOption == "Chance Jail Card")
            {
                m_gameController.TradeMade(m_playerName, selectedOption, inputCash, false, true);
                return;
            }

            // Property traded
            m_gameController.TradeMade(m_playerName, selectedOption, inputCash, true, false);
            return;
        }

        // Send to controller if just cash traded
        if (inputCash > 0)
        {
            m_gameController.TradeMade(m_playerName, selectedOption, inputCash, false, false);
            return;
        }
    }
    /* void SendToGame() */

    // User done with menu, close it
    void OnDoneClick() { m_tradingMenu.SetActive(false); }

    void OnCashInput(string a_inputText)
    {
        // Check if empty
        if (string.IsNullOrEmpty(a_inputText))
        {
            m_sendButton.interactable = true;
            return;
        }
        // Attempt to cast to int
        int amount;
        if (!int.TryParse(a_inputText, out amount))
        {
            m_sendButton.interactable = false;
            return;
        }

        // Check value validity
        if (amount >= 0 && amount < m_availibleCash)
            m_sendButton.interactable = true;
        else
            m_sendButton.interactable = false;
    }
}
