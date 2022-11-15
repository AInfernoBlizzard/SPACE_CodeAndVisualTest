using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Event_Template> eventDeck;


    
    public float Money;
    public float Staff;
    public float Equip;
    public float Quality;
    public float Popularity;


    public float MoneyMultiplier = 1;
    public float StaffMultiplier = 1;
    public float EquipMultiplier = 1;
    public float QualityMultiplier = 1;
    public float PopularityMultiplier = 1;

    public float PowerUpTicker;

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

        if (Money > 99)
        {
            SceneManager.LoadScene("Money100");
        }

        if (Popularity < 1)
        {
            SceneManager.LoadScene("Popularity0");
        }
        
        if (Popularity > 99)
        {
            SceneManager.LoadScene("Popularity100");
        }

        if (Equip < 1)
        {
            SceneManager.LoadScene("Equipment0");
        }

        if (Equip > 99)
        {
            SceneManager.LoadScene("Equipment100");
        }

        if (Quality < 1)
        {
            SceneManager.LoadScene("Quality0");
        }

        if (Quality > 99)
        {
            SceneManager.LoadScene("Quality100");
        }

    }


    void ResetMultipliers()
    {
        //Deactivate the graphics
        MoneyMultiplier = 1f;
        StaffMultiplier = 1f;
        EquipMultiplier = 1f;
        QualityMultiplier = 1f;
        PopularityMultiplier = 1f;
    }
    void MoneyPowerUp(float NumberOfTurns)
    {
        ResetMultipliers();
        MoneyMultiplier = 2f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void PopularityPowerUp(float NumberOfTurns)
    {
        ResetMultipliers();
        PopularityMultiplier = 2f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void EquipmentPowerUp(float NumberOfTurns)
    {
        ResetMultipliers();
        EquipMultiplier = 2f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void StaffPowerUp(float NumberOfTurns)
    {
        ResetMultipliers();
        StaffMultiplier = 2f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void QualityPowerUp(float NumberOfTurns)
    {
        ResetMultipliers();
        QualityMultiplier = 2f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void MoneyPowerUp2(float NumberOfTurns)
    {
        ResetMultipliers();
        MoneyMultiplier = 0.5f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void PopularityPowerUp2(float NumberOfTurns)
    {
        ResetMultipliers();
        PopularityMultiplier = 0.5f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void EquipmentPowerUp2(float NumberOfTurns)
    {
        ResetMultipliers();
        EquipMultiplier = 0.5f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void StaffPowerUp2(float NumberOfTurns)
    {
        ResetMultipliers();
        StaffMultiplier = 0.5f;
        PowerUpTicker = NumberOfTurns;
        //Activate the graphic
    }
    void QualityPowerUp2(float NumberOfTurns)
    {
        ResetMultipliers();
        QualityMultiplier = 0.5f;
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
