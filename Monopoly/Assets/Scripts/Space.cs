using System;
public class Space : IComparable<Space>
{
    // ======================================== Private Data Members ======================================= //
    protected string m_name;
    protected int m_index;
    protected Board.Actions m_actionType;
    protected string m_description;

    // ======================================== Constructor ================================================ //

    public Space(string a_name, int a_index, Board.Actions a_action, string a_description)
    {
        Name = a_name;
        Index = a_index;
        ActionType = a_action;
        Description = a_description;
    }

    // ======================================== Virtual Methods ============================================ //

    // Returns the description of the space
    public virtual string Description
    {
        get { return m_description; }
        set { m_description = value; }
    }

    // Whether or not this space is mortgaged.
    public virtual bool IsMortgaged
    {
        get { return false; }
        set { throw new System.Exception("Attempting to mortgage a non-property type!"); }
    }

    // What action a player must do, landing on this property
    public virtual Board.Actions ActionType
    {
        get { return m_actionType; }
        set { m_actionType = value; }
    }

    // ======================================== Properties ================================================= //
    
    // Name of the property
    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    // Property's location on the board
    public int Index
    {
        get { return m_index; }
        set { m_index = value; }
    }

    // ======================================== Public Methods ============================================= //

    public int CompareTo(Space other)
    {
        // This is of type color property 
        if (this is ColorProperty)
        {
            // Both color properties, sort by index
            if (other is ColorProperty)
            {
                if (Index > other.Index) 
                    return -1;
                else
                    return 1;
            }
            // Other space isn't color property
            return -1;
        }
        // This is a railroad
        if (this is Railroad)
        {
            // Other is a color property
            if (other is ColorProperty)
                return 1;

            // Both railroads
            if (other is Railroad) 
            { 
                if (Index > other.Index)
                    return -1;
                return 1;
            }

            // Other is a utility
            return -1;
        }
       
        // Both utilities
        if (other is Utility)
        {
            if (Index > other.Index)
                return -1;
            return 1;
        }

        // Other isn't a utility
        return 1;
    }
    /* public int CompareTo(Space other) */
}
