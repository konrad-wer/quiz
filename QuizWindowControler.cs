using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Quiz
{
    class QuizWindowControler
    {
        Quiz quiz;
        IEnumerator<Question> enumerator;
        bool isQuestionLoaded;
        int points = 0;

        public QuizWindowControler(string filePath)
        {
            quiz = new Quiz();

            if (Directory.Exists("opening_quiz_temporary_foldr"))
                Directory.Delete("opening_quiz_temporary_foldr", true);
            ZipFile.ExtractToDirectory(filePath, @"opening_quiz_temporary_foldr\");


            foreach (var entry in XDocument.Load(@"opening_quiz_temporary_foldr\control.xml").Descendants("entry"))
            {
                var q = entry.Element("question").Value;
                var a = entry.Element("ansA").Value;
                var b = entry.Element("ansB").Value;
                var c = entry.Element("ansC").Value;
                var d = entry.Element("ansD").Value;
                var r = int.Parse(entry.Element("right").Value);

                if (entry.Element("multimedia").Value == "true")
                {
                    var fp = entry.Element("filepath").Value;
                    var extension = fp.Substring(fp.LastIndexOf(".") + 1);

                    if (new string[] { "bmp", "jpg", "jpeg", "png", "tiff", "tif" }.Contains(extension))
                        quiz.AddQuestion(new ImageQuestion(q, a, b, c, d, r, new Bitmap(Image.FromFile(@"opening_quiz_temporary_foldr\" + fp))));

                    if (extension == "wav")
                        quiz.AddQuestion(new SoundQuestion(q, a, b, c, d, r, new SoundPlayer(@"opening_quiz_temporary_foldr\" + fp)));

                }
                else
                    quiz.AddQuestion(new Question(q, a, b, c, d, r));
            }

            quiz.Shuffle();
            enumerator = (quiz as IEnumerable<Question>).GetEnumerator();
        }

        public Question GetNextQuestion()
        {
            if (isQuestionLoaded = enumerator.MoveNext())
                return enumerator.Current;
            else
                return null;
        }

        public bool CheckAnswer(int index)
        {
            if (isQuestionLoaded)
                return index == enumerator.Current.RightAnswerIndex;
            else
                return false;
        }

        public void AddPoint()
        {
            points++;
        }

        public int Points
        {
            get { return points; }
        }

        public int QuestionsCount
        {
            get { return quiz.Count; }
        }
             
        public void Clear()
        {
            quiz.Clear();
        }

    }
}
