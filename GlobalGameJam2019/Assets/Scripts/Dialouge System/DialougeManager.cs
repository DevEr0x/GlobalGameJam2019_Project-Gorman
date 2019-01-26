using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour{

    public Text dialougeName;
    public Text dialougeText;

    public Animator animator;

    private bool inConversation = false;

    private Queue<string> sentences;

    void Start(){
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge dialouge) {
        Debug.Log("Starting Dialouge with " + dialouge.name);
        dialougeName.text = dialouge.name;
        sentences.Clear();
        inConversation = true;
        animator.SetBool("inDialouge", true);

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

        public void DisplayNextSentence(){
            if(sentences.Count == 0){
                EndDialouge();
                return;
            }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
        }

    IEnumerator TypeSentence(string sentence){
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialougeText.text += letter;
            yield return null;
        }
    }

        void EndDialouge(){
            Debug.Log("End of conversation.");
        inConversation = false;
        animator.SetBool("inDialouge", false);
    }

    void Update(){
        if (inConversation){
            if (Input.GetKeyDown(KeyCode.Space)){
                DisplayNextSentence();
            }
        }
    }
}

