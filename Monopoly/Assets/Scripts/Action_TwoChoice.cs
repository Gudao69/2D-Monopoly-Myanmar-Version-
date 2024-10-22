using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Action_TwoChoice : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public Controller_Game m_gameController;
    public TMP_Text m_title;
    public Button m_leftButton;
    public Button m_rightButton;
    public TMP_Text m_leftButtonText;
    public TMP_Text m_rightButtonText;

    // ======================================== Properties ================================================= //

    // Returns reference to the left button
    public Button LeftButton { get { return m_leftButton; } }

    // Returns reference to the right button
    public Button RightButton { get { return m_rightButton; } }

    // Sets the text for the left button
    public string LeftButtonText { set { m_leftButtonText.text = value; } }

    // Sets the text for the left button
    public string RightButtonText { set { m_rightButtonText.text = value; } }

    // Sets the color of the act button's text, and font according to the color
    public Color LeftButtonColor
    {
        set
        {
            // Make bold if an actual color
            if (value != Color.black)
                m_leftButtonText.fontStyle = FontStyles.Bold;
            
            // If it's black make it a normal font style
            else
                m_leftButtonText.fontStyle = FontStyles.Normal;
            
            m_leftButtonText.color = value;
        }
    }

    // Sets the color of the act button's text, and font according to the color
    public Color RightButtonColor
    {
        set
        {
            // Make bold if an actual color
            if (value != Color.black)
                m_rightButtonText.fontStyle = FontStyles.Bold;

            // If it's black make it a normal font style
            else
                m_rightButtonText.fontStyle = FontStyles.Normal;
            
            m_rightButtonText.color = value;
        }
    }

    // Sets the title text of the window
    public string Title { set { m_title.text = value; } }
}
