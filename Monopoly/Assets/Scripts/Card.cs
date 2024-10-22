
public class Card
{
    // ======================================== Private Data Members ======================================= //
    Controller_Card.Actions m_actionType;
    string m_description;
    int m_value;
    int m_value2;
    string m_location;

    // ======================================== Constructor ================================================ //

    public Card(Controller_Card.Actions a_actionType, string a_description)
    {
        m_actionType = a_actionType;
        m_description = a_description;
    }

    // ======================================== Properties ================================================= //

    // Access card's action type
    public Controller_Card.Actions ActionType { get { return m_actionType; } }

    // Access description of the card
    public string Description { get { return m_description; } }

    public int Value
    {
        set { m_value = value; }
        get
        {
            // Check access exception
            if (m_actionType == Controller_Card.Actions.getJailCard
                || m_actionType == Controller_Card.Actions.move)
                throw new System.Exception("Accessing invalid property (Value) for this card");
            return m_value;
        }
    }

    public int Value2
    {
        set { m_value2 = value; }
        get
        {
            // Check access exception (only for repairing cards)
            if (m_actionType != Controller_Card.Actions.makeRepairs)
                throw new System.Exception("Accessing invalid property (Value2) for this card");
            return m_value2;
        }
    }

    public string Location
    {
        set { m_location = value; }
        get
        {
            // Check access exception (only for moving actions)
            if (m_actionType != Controller_Card.Actions.move)
                throw new System.Exception("Accessing invalid property (Value) for this card");
            return m_location;
        }
    }
}
