using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Action_RollDice : MonoBehaviour
{
    // ======================================== Unity Data Members ========================================= //
    public Controller_Game m_gameController;
    public Image m_die1;
    public Image m_die2;
    public Button m_diceButton;
    public Button m_continueButton;
    public TMP_Text m_continueText;
    public List<Sprite> m_diceSprites;
    public TMP_Text m_title;

    // ======================================== Private Data Members =========================+============= //
    const float m_ANIMATION_DURATION = .5f;
    bool m_orderDetermined;
    int m_diceResult;
    bool m_wereDoubles;
    bool m_utilityCostRoll;

    // ======================================== Start / Update ============================================= //
    void Start()
    {
        // Initialize listeners
        m_diceButton.onClick.AddListener(OnDiceClick);
        m_continueButton.onClick.AddListener(OnContinueClick);

        // Initialize the bools 
        m_orderDetermined = false;
        m_utilityCostRoll = false;

        // Set the window
        ResetWindow();
    }

    // ======================================== Properties ================================================= //

    // Flag to mark whether or not the dice rolling is for determining order
    // at the start of a new game
    public bool OrderDetermined
    {
        get { return m_orderDetermined; }
        set { m_orderDetermined = value; }
    }

    // Flag to mark whether or not the dice rolling is for determining the 
    // cost of landing on a Utility
    public bool UtilityCostRoll
    {
        get { return m_utilityCostRoll; }
        set { m_utilityCostRoll = value; }
    }

    // Flag to mark whether or not a player rolled doubles, this only needs to be
    // updated when a player goes to jail
    public bool RolledDoubles { set { m_wereDoubles = value; } }

    // ======================================== Public Methods ============================================= //

    public void ResetWindow()
    {
        // Set title according to flags
        if (!OrderDetermined)
            m_title.text = "Roll Dice to Determine Order...";
        
        else if (UtilityCostRoll)
            m_title.text = "Roll Dice to Determine Utility Rent Price...";
        
        else if (m_wereDoubles)
            m_title.text = "You rolled doubles, roll again!";
        
        else
            m_title.text = "Roll Dice";
        
        // Reset the Unity objects
        m_continueButton.interactable = false;
        m_continueText.color = Color.red;
        m_diceButton.interactable = true;
        m_die1.sprite = m_diceSprites[0];
        m_die2.sprite = m_diceSprites[0];
    }
    /* public void ResetWindow() */

    // ======================================== Private Methods ============================================ //

    // Initiates dice roll animation when a user clicks the dice icon
    void OnDiceClick()
    {
        // Disabled the button after user clicks
        m_diceButton.interactable = false;

        // Coroutine method started to animate dice while game still runs
        StartCoroutine(RollDice());
    }

    IEnumerator RollDice()
    {
        // Shows a new die face for every frame, run for 1/2 a second
        float elapsedTime = 0f;
        int die1Val = 0;
        int die2Val = 0;
        while (elapsedTime < m_ANIMATION_DURATION) 
        {
            // Set the dice face to a random die face sprite
            die1Val = Random.Range(1, 7);
            die2Val = Random.Range(1, 7);
            m_die1.sprite = m_diceSprites[die1Val];
            m_die2.sprite = m_diceSprites[die2Val];

            // Update the time passed
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        // Roll complete, assign die data
        m_diceResult = die1Val + die2Val;
        m_wereDoubles = false;
        if (die1Val == die2Val)
            m_wereDoubles = true;

        // Do not mark doubles as true if this is initializing the player order
        if (!OrderDetermined)
            m_wereDoubles = false;

        // Update the window
        m_title.text = "You Rolled a " + m_diceResult + "!";
        if (m_wereDoubles && OrderDetermined)
            m_title.text += "\nYou rolled Doubles!";
        
        m_continueText.color = Color.green;
        m_continueButton.interactable = true;
    }
    /* IEnumerator RollDice() */

    void OnContinueClick()
    {
        // Determine what action method to call in game controller class
        if (!m_orderDetermined)
            m_gameController.Action_OrderDetermined(m_diceResult);

        else if (UtilityCostRoll)
            m_gameController.Action_UtilityCostDetermined(m_diceResult);
        
        else
            m_gameController.Action_DiceRolled(m_diceResult, m_wereDoubles);

        // Reset the window for next use of this class
        ResetWindow();
    }
}
