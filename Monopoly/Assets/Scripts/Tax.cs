public class Tax : Space
{
    // ======================================== Private Data Members ======================================= //
    int m_taxCost;

    // ======================================== Constructor ================================================ //
    
    public Tax(string a_name, int a_index, Board.Actions a_action, int a_taxCost, string a_description) 
        : base(a_name, a_index, a_action, a_description)
    {
        m_taxCost = a_taxCost;
    }

    // ======================================== Properties ================================================= //
    
    // Returns how much the tax costs for this tax space
    public int TaxCost { get { return m_taxCost; } }
}
