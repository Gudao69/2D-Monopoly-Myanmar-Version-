using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller_EndGame : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public TMP_Text m_title;
    public Sprite m_icon;
    public List<Sprite> m_icons;
    public TMP_Text m_cash;
    public TMP_Text m_propertyList;
    public Button m_exitButton;

    // ======================================== Start / Update ============================================= //

    // Creates the scene from text file data
    void Start()
    {
        // Read the end game file
        string[] data = File.ReadAllLines(Application.streamingAssetsPath + "endGameData.txt");

        // Assign all the text
        m_title.text = data[0] + " Won!";
        m_cash.text = "Total final cash: $" + data[2];
        m_propertyList.text = data[3];

        // Find the icon and assign it
        foreach (Sprite icon in m_icons)
        {
            if (icon.ToString() == data[1])
                m_icon = icon;
        }

        // Add exit button listener
        m_exitButton.onClick.AddListener(Application.Quit);
    }
}
