using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{


    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] AnswerButtons;
    int correctAnswerindex;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        DisplayQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = AnswerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerindex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerindex);
            questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;
            buttonImage = AnswerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        SetButtonState(false);
        timer.CancelTimer();
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }
    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        
        for(int i = 0; i < 4; i++)
        {
            TextMeshProUGUI buttonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
    
    void SetButtonState(bool state)
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Button button = AnswerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
         for(int i = 0; i < 4; i++)
        {
            Image button = AnswerButtons[i].GetComponent<Image>();
            button.sprite = defaultAnswerSprite;
        }
    }
}
