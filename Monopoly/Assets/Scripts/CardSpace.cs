public class CardSpace : Space
{
    // ======================================== Private Data Members ======================================= //
    Controller_Card m_cardController;

    // ======================================== Constructor ================================================ //

    public CardSpace(string a_name, int a_index, Board.Actions a_action, Controller_Card a_cardController, 
        string a_description) : base(a_name, a_index, a_action, a_description)
    {
        m_cardController = a_cardController;
    }

    // ======================================== Public Methods ============================================= //

    public Card TakeCard()
    {
        // Return appropriate card from respective deck
        if (Name == "Chance")
            return m_cardController.TakeChanceCard();
        
        else
            return m_cardController.TakeCommunityChestCard();
    }
}
