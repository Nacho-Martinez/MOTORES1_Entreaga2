using UnityEngine;



    public class DialogueAndTp : ActivateAndAssingDialogue
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            Dialogue.Instance.onDialogueComplete += Tp;
            
        }

        private void Tp()
        {
            Debug.Log("Dialogo acabado haciendo Tp.......");
        }
    }
