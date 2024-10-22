using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Action_Generic : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public TMP_Text m_title;
    public Button m_actButton;
    public TMP_Text m_actButtonText;

    // ======================================== Properties ================================================= //

    // Set the title text
    public string Title { set { m_title.text = value; } }

    // Set the action button's text
    public string ActButtonText { set { m_actButtonText.text = value; } }

    // Returns a reference to the act button (for adding listeners)
    public Button ActButton { get { return m_actButton; } }

    // Sets the color of the act button's text, and font
    // according to the color
    public Color ActButtonColor
    {
        set 
        {
            // Make bold if an actual color
            if (value != Color.black)
            {
                m_actButtonText.fontStyle = FontStyles.Bold;
            }
            else
            {
                m_actButtonText.fontStyle = FontStyles.Normal;
            }
            m_actButtonText.color = value; 
        }
    }

    // ======================================== Public Methods ============================================= //

    // Resets the act button (removes listeners)
    public void ResetListeners()
    {
        m_actButton.onClick.RemoveAllListeners();
    }
}
