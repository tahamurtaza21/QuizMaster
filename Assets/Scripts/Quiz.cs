using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO question;
    [SerializeField] GameObject[] AnswerButtons;
    int correctAnswerindex;

    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();
        
        for(int i = 0; i < 4; i++)
        {
            TextMeshProUGUI buttonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
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
    }
}
