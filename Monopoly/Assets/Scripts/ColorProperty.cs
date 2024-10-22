using System.Collections.Generic;
public class ColorProperty : Property
{
    // ======================================== Private Data Members ======================================= //
    int m_houseCost;
    int m_numHouses;
    string m_color;

    // ======================================== Constructor ================================================ //

    public ColorProperty(string a_name, int a_index, Board.Actions a_action, int a_purchasePrice, int a_houseCost, 
        List<int> a_rentPrices, string a_description, string a_color) 
        : base (a_name, a_index, a_action, a_purchasePrice, a_description)
    {
        Houses = 0;
        m_houseCost = a_houseCost;
        m_rentPrices = a_rentPrices;
        m_color = a_color;
    }

    // ======================================== Override Methods =========================================== //

    public override int RentPrice
    {
        get
        {
            // Rent doubles for undeveloped properties if whole set owned
            if (ColorSetOwned && Houses == 0)
                return m_rentPrices[0] * 2;

            // Otherwise standard price
            return m_rentPrices[Houses];
        }
    }

    public override string Description
    {
        get
        {
            // Get generic information from base class
            string retString = base.Description;

            // Houses
            if (Houses == 5)
                retString += "\nHotels: 1\n";
            else
                retString += "\nHouses: " + Houses + "\n";
            
            // Add rest of description, static
            retString += "Purchase cost: $" + PurchasePrice + "\n" +
                "RENT: $" + m_rentPrices[0] + "\n" +
                "With 1 House: $" + m_rentPrices[1] + "\n" +
                "With 2 Houses: $" + m_rentPrices[2] + "\n" +
                "With 3 Houses: $" + m_rentPrices[3] + "\n" +
                "With 4 Houses: $" + m_rentPrices[4] + "\n" +
                "With HOTEL: $" + m_rentPrices[5] + "\n" +
                "Mortgage Value: $" + MortgageValue + "\n" +
                "Houses cost $" + HouseCost + " each\n" +
                "Hotels, $" + HouseCost + " each, plus 4 houses";

            return retString;
        }
    }
    /* public override string Description */

    // ======================================== Properties ================================================= //

    // Accessor for much houses cost to purchase
    public int HouseCost { get { return m_houseCost; } }

    // Accessor for how many houses are on this property
    public int Houses
    {
        get { return m_numHouses; }
        set { m_numHouses = value; }
    }

    // Accessor for the color of this property 
    public string Color { get { return m_color; } }

    public bool ColorSetOwned
    {
        get
        {
            // Check every property owner has
            int colorSetCount = 0;
            foreach (Property property in Owner.Properties)
            {
                // Check only color properties
                if (property is ColorProperty)
                {
                    ColorProperty colorProperty = (ColorProperty)property;
                    if (colorProperty.Color == m_color)
                        colorSetCount++;
                }
            }

            // If 3, automatically full set
            if (colorSetCount == 3)
                return true;

            // Brown and dark blue only need 2 
            if (m_color == "Brown" || m_color == "Dark Blue")
            {
                if (colorSetCount == 2)
                    return true;
            }

            return false;
        }
    }
    /* public bool ColorSetOwned */
}
