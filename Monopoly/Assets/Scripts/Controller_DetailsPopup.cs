using TMPro;
using UnityEngine;

public class Controller_DetailsPopup : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public TMP_Text m_name;
    public TMP_Text m_details;
    public GameObject m_window;

    // ======================================== Private Data Members ======================================= //
    bool m_isActive;

    // ======================================== Start / Update ============================================= //
    void Update()
    {

    }

    // ======================================== Public Methods ============================================= //

    public void CreateDetailsWindow(string a_title, string a_text)
    {
        // Set up the name and details
        m_name.text = a_title;
        m_details.text = a_text;

        // Update flag
        m_isActive = true;

        // Enable the window
        m_window.SetActive(true);
    }

    // Closes the window and marks flag
    public void CloseDetailsWindow()
    {
        m_window.SetActive(false);
        m_isActive = false;
    }
}

