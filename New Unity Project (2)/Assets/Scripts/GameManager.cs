using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Event_Template> eventDeck;


    
    public int Money;
    public int Staff;
    public int Equip;
    public int Quality;
    public int Popularity;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        MoneyBar.fillAmount = Money / 100.00f;
        StaffBar.fillAmount = Staff / 100.00f;
        EquipBar.fillAmount = Equip / 100f;
        QualityBar.fillAmount = Quality / 100f;
        PopularityBar.fillAmount = Popularity / 100f;
        */
        if (!eventSet)
        {
            DrawNewEvent();
            eventSet = true;
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
            Money += eventDeck[0].Money_1;
            Staff += eventDeck[0].Staff_1;
            Equip += eventDeck[0].Equip_1;
            Quality += eventDeck[0].Quality_1;
            Popularity += eventDeck[0].Popularity_1;
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
            Money += eventDeck[0].Money_2;
            Staff += eventDeck[0].Staff_2;
            Equip += eventDeck[0].Equip_2;
            Quality += eventDeck[0].Quality_2;
            Popularity += eventDeck[0].Popularity_2;
            //change to outcome text and button
            MainBodyText.text = eventDeck[0].Explanation_2;
            //disable one button
            ChoiceOneText.text = "OK";
            ChoiceTwoText.gameObject.transform.parent.gameObject.SetActive(false);
            //check end game situations
            EndGameCheck();
        }

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

    }
}
