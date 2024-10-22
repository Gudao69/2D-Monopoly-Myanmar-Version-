using System.Collections.Generic;

public class Property : Space
{
    // ======================================== Private Data Members ======================================= //
    protected int m_purchasePrice;
    protected Player m_owner = null;
    protected bool m_purchased = false;
    protected bool m_mortgaged = false;
    protected List<int> m_rentPrices = new List<int>();

    public Property(string a_name, int a_index, Board.Actions a_action, int a_purchasePrice, string a_description) : 
        base(a_name, a_index, a_action, a_description)
    {
        PurchasePrice = a_purchasePrice;
    }

    // ======================================== Virtual Methods ============================================ //
    
    // Rent
    public virtual int RentPrice { get { throw new System.Exception("Virtual base class rent price method being called"); } }

    // ======================================== Override Methods =========================================== //

    // If mortgaged
    public override bool IsMortgaged
    {
        get { return m_mortgaged; }
        set { m_mortgaged = value; }
    }

    public override Board.Actions ActionType
    {
        get
        {
            if (IsPurchased)
            {
                if (Owner.InJail)
                    return Board.Actions.LandedOn_JailedOwnerProperty;

                if (IsMortgaged)
                    return Board.Actions.LandedOn_MortgagedProperty;

                return Board.Actions.LandedOn_OwnedColorProperty;
            }
            return Board.Actions.LandedOn_UnownedProperty;
        }
    }

    // Generic information about who own's the property, and if it's mortgaged
    public override string Description
    {
        get
        {
            // Owned or not
            string retString = "Owner: ";
            if (IsPurchased)
                retString += Owner.Name;
            else
                retString += "No one";


            // Mortgaged or not
            retString += "\nMortgaged: ";
            if (IsMortgaged)
                retString += "Yes";
            else
                retString += "No";
            return retString;
        }
    }

    // ======================================== Properties ================================================= //

    // How much the property costs for a player to buy
    public int PurchasePrice
    {
        get { return m_purchasePrice; } 
        set { m_purchasePrice = value; }
    }

    // How much the property mortgages for
    public int MortgageValue { get { return m_purchasePrice / 2 ; } }

    // Player who owns the property
    public Player Owner
    {
        get { return m_owner; }
        set { m_owner = value; }
    }

    // Flag to indicate whether property has been purchased
    public bool IsPurchased
    { 
        get { return m_purchased; } 
        set { m_purchased = value; }
    }
}
