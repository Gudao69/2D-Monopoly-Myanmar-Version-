using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Popup : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public GameObject m_popupWindow;
    public Button m_popupCloseButton;
    public TMP_Text m_title;
    public TMP_Text m_message;
    public Controller_Camera m_cameraController;
    public GameObject m_blocker;

    // ======================================== Start / Update ============================================= //
    public void Start()
    {
        m_popupCloseButton.onClick.AddListener(ClosePopupWindow);
        m_blocker.SetActive(false); 
    }

    // ======================================== Public Methods ============================================= //

    // Closes the popup window 
    public void ClosePopupWindow()
    {
        // Enable zooming for camera if a controller class is defined
        try { m_cameraController.ZoomEnabled = true; }
        catch { }

        // Disable the window
        m_popupWindow.SetActive(false);
        m_blocker.SetActive(false);
    }

    public void CreatePopupWindow(string a_title, string a_message, char a_type = 'N')
    {
        // Set name and message
        m_title.text = a_title;
        m_message.text = a_message;

        // Set the color depending on type
        if (a_type == 'E')
            m_title.color = Color.red;
        
        else if (a_type == 'G')
            m_title.color = Color.green;
        
        else
            m_title.color = Color.white;
        

        // Disable zooming if a camera controller is defined
        try { m_cameraController.ZoomEnabled = false; }
        catch { }

        // Set the popup window as active
        m_popupWindow.SetActive(true);
        m_blocker.SetActive(true);
    }
}
