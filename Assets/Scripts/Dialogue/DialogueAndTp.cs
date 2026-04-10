using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogueAndTp : ActivateAndAssingDialogue
{
    [SerializeField] private string levelTP;
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            Dialogue.Instance.onDialogueComplete += Tp;
            
        }

        private void Tp()
        {
            SceneManager.LoadScene(levelTP);
        }

        private void OnDisable()
        {
            Dialogue.Instance.onDialogueComplete -= Tp;
        }
    }
