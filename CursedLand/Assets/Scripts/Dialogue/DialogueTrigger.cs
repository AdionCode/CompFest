using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //[Header("Visual Cue")]
    //[SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool isnight;

    private void Awake() 
    {
        //playerInRange = false;
        //visualCue.SetActive(false);
    }

    private void Update() 
    {
        isnight = TimeManager.GetInstance().isNight;
        if (isnight)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
        //  && !DialogueManager.GetInstance().dialogueIsPlaying
        //if (playerInRange) 
        //{
            //visualCue.SetActive(true);
            
            //if (InputManager.GetInstance().GetInteractPressed()) 
            //{
            //    Debug.log(inkJSON.text);
            //    // DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            //}
        //}
        //else 
        //{
            //visualCue.SetActive(false);
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collider) 
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        playerInRange = true;
    //        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collider) 
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        playerInRange = false;
            
    //    }
    //}
}