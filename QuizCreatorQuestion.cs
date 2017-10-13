using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class QuizCreatorQuestion
    {
        private int rightAnswerIndex;
        public bool Multimedia { get; set; } = false;

        public int RightAnswerIndex
        {
            get { return rightAnswerIndex; }
            set
            {
                if (value < 0 || value > 3)
                    throw new IndexOutOfRangeException("RightAnswerIndex should be value from {0,1,2,3}");
                else
                    rightAnswerIndex = value;
            }
        }

        public string Question { get; set; } = "";

        string[] answers = { "", "", "", "" };


        public string this[int index]
        {
            get { return answers[index]; }
            set { answers[index] = value; }
        }

        public string FilePath = "";

        public void ClearFilePath()
        {
            FilePath = "";
        }
    }
}
