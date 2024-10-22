public class Railroad : Property
{

    // ======================================== Constructor ================================================ //

    public Railroad(string a_name, int a_index, Board.Actions a_action, 
        int a_purchasePrice, int a_rentPrice, string a_description)
        : base (a_name, a_index, a_action, a_purchasePrice, a_description)
    {
        // Initialize land on prices
        m_rentPrices.Add(a_rentPrice);
        m_rentPrices.Add(a_rentPrice * 2);
        m_rentPrices.Add(a_rentPrice * 4);
        m_rentPrices.Add(a_rentPrice * 8);
    }

    // ======================================== Override Methods =========================================== //

    
    public override int RentPrice { get { return m_rentPrices[AlliedRailroads - 1]; } }

    public override string Description
    {
        get 
        {
            // Get generic information from base class
            string retString = base.Description;

            // Get railroad specific data
            retString += "\nRENT: $" + m_rentPrices[0] + "\n" +
                "If 2 Railroads are owned: $" + m_rentPrices[1] + "\n" +
                "If 3 Railroads are owned: $" + m_rentPrices[2] + "\n" +
                "If 4 Railroads are owned: $" + m_rentPrices[3] + "\n" +
                "Mortgage Value: $" + MortgageValue;

            return retString;
        }
    }

    // ======================================== Properties ================================================= //

    // Returns how many railroads in total, the player owns. 
    public int AlliedRailroads
    {
        get
        {
            // Parse every property and find out how many are railroads
            int railroadCount = 0;
            foreach (Property property in Owner.Properties)
            {
                // Only count if of type railroad
                if (property is Railroad)
                    railroadCount++;
            }
            return railroadCount;
        }
    }
}
