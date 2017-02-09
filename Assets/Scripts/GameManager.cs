using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	
    public List<Letter> letters = new List<Letter>();
    public string Word = "AVIAO";

    public GameObject MessageModal { get; private set; }

    void Start () {

        GenerateRelatedLetters();

        MessageModal = GameObject.Find("Message");
        MessageModal.SetActive(false);
        	
	}


    void GenerateRelatedLetters()
    {

        int i = 0;

        foreach (Letter ltr in letters)
        {
            for(i = 0; i < Word.Length - 1; i++)
            if (ltr.value == Word[i])
            {
               
                ltr.Related.Add(GetLetterFromValue(Word[i+1]));
              
            }
           

        }

    }

    private Letter GetLetterFromValue(char value)
    {
        foreach (Letter ltr in letters)
        {
            if (ltr.value == value)
                return ltr;

        }

        return null;
    }


    public void CheckWord()
    {
        int totalConected = 0;

        foreach (Letter ltr in letters)
            if (ltr.isConnected)
                totalConected++;


        if (totalConected == Word.Length - 1)
        {
            Debug.Log("Palavra montada com sucesso");
            MessageModal.SetActive(true);
        }
            

    }
}
