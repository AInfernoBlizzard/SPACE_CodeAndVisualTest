using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Event_Template> eventDeck;


    
    public int Money;
    public int Staff;
    public int Equip;
    public int Quality;
    public int Popularity;


    public int MoneyMultiplier = 1;
    public int StaffMultiplier = 1;
    public int EquipMultiplier = 1;
    public int QualityMultiplier = 1;
    public int PopularityMultiplier = 1;

    public int PowerUpTicker;

    public Image MoneyBar;
    public Image StaffBar;
    public Image EquipBar;
    public Image QualityBar;
    public Image PopularityBar;

    public Text MainBodyText;

    public Text ChoiceOneText;
    public Text ChoiceTwoText;

    private bool eventSet;
    private bool showAfter;
    private bool endGame;


    // Start is called before the first frame update
    void Start()
    {
        generateEventDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoneyBar.fillAmount = Money / 100.00f;
        StaffBar.fillAmount = Staff / 100.00f;
        EquipBar.fillAmount = Equip / 100f;
        QualityBar.fillAmount = Quality / 100f;
        PopularityBar.fillAmount = Popularity / 100f;
        
        if (!eventSet)
        {
            DrawNewEvent();
            eventSet = true;
            if (PowerUpTicker == 1)
            {
                ResetMultipliers();
                PowerUpTicker = 0;
            }
            else
            {
                PowerUpTicker--;
            }
        }

        
    }

    public void DrawNewEvent()
    {
        ChoiceTwoText.gameObject.transform.parent.gameObject.SetActive(true);
        //add text for event
        MainBodyText.text = eventDeck[0].SituationTest;
        //add text for buttons
        ChoiceOneText.text = eventDeck[0].TextButton1;
        ChoiceTwoText.text = eventDeck[0].TextButton2;


    }

    public void ChooseAnOutcome(Text choice)
    {
        
        if (choice.text == "Continue")
        {
            EndGameExplanation();
        }

        if (choice.text == "Restart")
        {
            // regenerate the deck
        }

        if (choice.text == "OK")
        {
            OutcomeOK();
        }
        if(choice.text == eventDeck[0].TextButton1)
        {
            //update resources based on event choice
            Money += eventDeck[0].Money_1 * MoneyMultiplier;
            Staff += eventDeck[0].Staff_1 * StaffMultiplier;
            Equip += eventDeck[0].Equip_1 * EquipMultiplier;
            Quality += eventDeck[0].Quality_1 * QualityMultiplier;
            Popularity += eventDeck[0].Popularity_1 * PopularityMultiplier;
            //change to outcome text and button
            MainBodyText.text = eventDeck[0].Explanation_1;
            //disable one button
            ChoiceOneText.text = "OK";
            ChoiceTwoText.gameObject.transform.parent.gameObject.SetActive(false);
            //check end game situations
            EndGameCheck();
        }

        if (choice.text == eventDeck[0].TextButton2)
        {
            //update resources based on event choice
            Money += eventDeck[0].Money_2 * MoneyMultiplier;
            Staff += eventDeck[0].Staff_2 * StaffMultiplier;
            Equip += eventDeck[0].Equip_2 * EquipMultiplier;
            Quality += eventDeck[0].Quality_2 * QualityMultiplier;
            Popularity += eventDeck[0].Popularity_2 * PopularityMultiplier;
            //change to outcome text and button
            MainBodyText.text = eventDeck[0].Explanation_2;
            //disable one button
            ChoiceOneText.text = "OK";
            ChoiceTwoText.gameObject.transform.parent.gameObject.SetActive(false);
            //check end game situations
            EndGameCheck();
        }

        if (Staff < 1)
        {
            SceneManager.LoadScene("Staff0");
        }

        if (Staff > 99) 
        {
            SceneManager.LoadScene("Staff100");
        }

        if (Money < 1) 
        {
            SceneManager.LoadScene("Money0");
        }

    }


    void ResetMultipliers()
    {
        //Deactivate the graphics
        MoneyMultiplier = 1;
        StaffMultiplier = 1;
        EquipMultiplier = 1;
        QualityMultiplier = 1;
        PopularityMultiplier = 1;
    }
    void MoneyPowerUp(int NumberOfTurns)
    {
        ResetMultipliers();
        MoneyMultiplier = 2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void PopularityPowerUp(int NumberOfTurns)
    {
        ResetMultipliers();
        PopularityMultiplier = 2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void EquipmentPowerUp(int NumberOfTurns)
    {
        ResetMultipliers();
        EquipMultiplier = 2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void StaffPowerUp(int NumberOfTurns)
    {
        ResetMultipliers();
        StaffMultiplier = 2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void QualityPowerUp(int NumberOfTurns)
    {
        ResetMultipliers();
        QualityMultiplier = 2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void MoneyPowerUp2(int NumberOfTurns)
    {
        ResetMultipliers();
        MoneyMultiplier = 1/2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void PopularityPowerUp2(int NumberOfTurns)
    {
        ResetMultipliers();
        PopularityMultiplier = 1/2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void EquipmentPowerUp2(int NumberOfTurns)
    {
        ResetMultipliers();
        EquipMultiplier = 1/2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void StaffPowerUp2(int NumberOfTurns)
    {
        ResetMultipliers();
        StaffMultiplier = 1/2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void QualityPowerUp2(int NumberOfTurns)
    {
        ResetMultipliers();
        QualityMultiplier = 1/2;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }

    public void EndGameCheck()
    {
        //all the checks for 100 and 0


        if (endGame)
        {
            ChoiceOneText.text = "Continue";
        }
    }

    public void EndGameExplanation()
    {
        ChoiceOneText.text = "Restart";
    }

    public void OutcomeOK()
    {
        eventDeck.Remove(eventDeck[0]);
        eventSet = false;
    }

    public void generateEventDeck()
    {
        
        for (int i = 0; i < eventDeck.Count; i++)
        {
            Event_Template temp = eventDeck[i];
            int randomIndex = Random.Range(i, eventDeck.Count);
            eventDeck[i] = eventDeck[randomIndex];
            eventDeck[randomIndex] = temp;
        }
    }
}
