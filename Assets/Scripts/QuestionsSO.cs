using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Questions", order = 0)]
public class QuestionsSO : ScriptableObject {    
    
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here.";
    [SerializeField] string[] Answers = new string[4];
    [SerializeField] int correctAnswerindex;
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerindex;
    }

    public string GetAnswer(int index)
    {
        return Answers[index];
    }


}
