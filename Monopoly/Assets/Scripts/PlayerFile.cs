using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class PlayerFile
{
    // ======================================== Private Data Members ======================================= //
    XmlWriter m_writer;
    XmlReader m_reader;
    string m_fileName = "playerData.xml";

    // ======================================== Public Methods ============================================= //

    public void CreatePlayerFile()
    {
        // Create document w/ indentation
        XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

        string filePath = Path.Combine(Application.streamingAssetsPath, m_fileName);
        m_writer = XmlWriter.Create(filePath, settings);

        // Root element
        m_writer.WriteStartDocument();
        m_writer.WriteStartElement("Players");
    }

    public void ClosePlayerFile()
    {
        m_writer.WriteEndElement();
        m_writer.WriteEndDocument();
        m_writer.Flush();
        m_writer.Close();
    }

    public void WritePlayerToFile(string a_name, string a_icon)
    {
        m_writer.WriteStartElement("Player");
        m_writer.WriteElementString("Name", a_name);
        m_writer.WriteElementString("Icon", a_icon);
        m_writer.WriteEndElement();
    }

    public Dictionary<string, string> ReadPlayersFromFile()
    {
        // Obtain file path 
        string filePath = Path.Combine(Application.streamingAssetsPath, m_fileName);


        // Setup the players dict
        Dictionary<string, string> players = new Dictionary<string, string>();

        // Setup the xmlreader object 
        using (m_reader = XmlReader.Create(filePath))
        {
            string name = string.Empty;
            string icon = string.Empty;

            // Read all the player data 
            while (m_reader.Read())
            {
                // We're reading in a player
                if (m_reader.NodeType == XmlNodeType.Element)
                {
                    if (m_reader.Name == "Name")
                    {
                        m_reader.Read(); // Move to the text inside <Name>
                        name = m_reader.Value; // Get the value
                    }
                    else if (m_reader.Name == "Icon")
                    {
                        m_reader.Read(); // Move to the text inside <Icon>
                        icon = m_reader.Value; // Get the value
                    }
                }

                // Done reading in players
                else if (m_reader.NodeType == XmlNodeType.EndElement && m_reader.Name == "Player")
                {
                    players[name] = icon;
                    name = string.Empty;
                    icon = string.Empty;
                }
            }
        }
        return players;
    }
    /* public Dictionary<string, string> ReadPlayersFromFile() */
}


