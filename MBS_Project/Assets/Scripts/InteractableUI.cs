using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour {

    public Vector3 endScale;
    public Vector3 startScale;

    public float journeyLength;
    float currentPercentage;
    public float speed = 1f;
    public float startTime;

    public GameObject targetImage;
    // Use this for initialization
    void Start () {
        startScale = targetImage.GetComponent<Transform>().localScale;

        journeyLength = Vector3.Distance(startScale, endScale);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
         StopCoroutine(hideCall());
         startTime = Time.time;
         StartCoroutine(showCall());

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StopCoroutine(showCall());

            startTime = Time.time;
            StartCoroutine(hideCall());
        }
    }

    IEnumerator showCall()
    {
        while(targetImage.GetComponent<Transform>().localScale != endScale)
        {
            
            float scaleChange = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = scaleChange / journeyLength;



            targetImage.GetComponent<Transform>().localScale = Vector3.Lerp(startScale, endScale, fracJourney);

            yield return new WaitForFixedUpdate();
        }


        
    }

    IEnumerator hideCall()
    {
        while (targetImage.GetComponent<Transform>().localScale != startScale)
        {

            float scaleChange = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = scaleChange / journeyLength;



            targetImage.GetComponent<Transform>().localScale = Vector3.Lerp(endScale, startScale, fracJourney);

            yield return new WaitForFixedUpdate();
        }



    }
}
