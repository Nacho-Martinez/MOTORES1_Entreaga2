using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance { get;  private set; }
    public bool IsDialogueActive { get; private set; } = false;
    
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField]private float textSpeed;
    private int index;
    public Action onDialogueComplete;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        
    }

    public void StartDialogue(string[] newLines)
    {
        IsDialogueActive = true;
        index = 0;
        Time.timeScale = 0f;
        textComponent.text = string.Empty;
        lines = newLines;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        
    }

   public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Time.timeScale = 1f;
            lines = null;
            IsDialogueActive = false;
            
            onDialogueComplete?.Invoke(); 
            onDialogueComplete = null;
            gameObject.SetActive(false);
        }
    }
}
