using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

    public char value;
    public List<Letter> Related = new List<Letter>();
    public bool isConnected;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    
    void FixedUpdate()
    {

        Vector3 ahead = transform.right;
        Vector3 rayStart = transform.position;
        Ray ray = new Ray(rayStart, ahead);
        RaycastHit hit;

       
        if (Physics.Raycast(ray, out hit, 3))
        {


                if(Related.Count > 0)

                foreach(Letter ltr in Related)
                {

                    if (hit.transform.gameObject.GetComponent<Letter>().value == ltr.value)
                    {
                        gameManager.CheckWord();
                        isConnected = true;
                    }
            
                   
                }
           
                
               Debug.DrawRay(rayStart, ahead * 3, Color.magenta);


        }
        else
        {

            isConnected = false;
        }

    }

}
