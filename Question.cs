using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Question
    {
        protected string question;
        protected string[] answers;
        private int rightAnswerIndex;
        
        public Question(string question, string a, string b, string c, string d, int rightAnswer)
        {
            answers = new string[4];
            this.question = question;
            answers[0] = a;
            answers[1] = b;
            answers[2] = c;
            answers[3] = d;
            rightAnswerIndex = rightAnswer;
        }

        public string GetQuestion()
        {
            return question;
        }

        public string this[int index]
        {
            get { return answers[index]; }
        }

        public int RightAnswerIndex
        {
            get { return rightAnswerIndex; }
        }
    }
}
