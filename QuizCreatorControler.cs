using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.IO.Compression;
using System.Windows.Forms;

namespace Quiz
{
    class QuizCreatorControler
    {
        List<QuizCreatorQuestion> questions = new List<QuizCreatorQuestion>();
        public int QuestionCount { get { return questions.Count; } }

        public QuizCreatorQuestion AddQuestion()
        {
            questions.Add(new QuizCreatorQuestion());
            return questions.Last();
        }

        public void RemoveQuestion(QuizCreatorQuestion q)
        {
            questions.Remove(q);
        }

        public void Clear()
        {
            questions.Clear();
        }


        public void SaveAsQuiz(string filePath)
        {
            if (Directory.Exists("saving_quiz_temporary_foldr"))
                Directory.Delete("saving_quiz_temporary_foldr", true);

            Directory.CreateDirectory("saving_quiz_temporary_foldr");
            var elements = new List<XElement>();

            foreach (var q in questions)
            {
   
                var filename = q.FilePath.Substring(q.FilePath.LastIndexOf("\\") + 1);
                bool exsist = false;
                if (q.Multimedia)
                    exsist = File.Exists(q.FilePath);

                var element = new XElement
                (
                    "entry",
                    new XElement("question", q.Question),
                    new XElement("ansA", q[0]),
                    new XElement("ansB", q[1]),
                    new XElement("ansC", q[2]),
                    new XElement("ansD", q[3]),
                    new XElement("right", q.RightAnswerIndex),
                    new XElement("multimedia", q.Multimedia && exsist),
                    new XElement("filepath", filename)
                );
                elements.Add(element);

                if (q.Multimedia)
                {
                    if (exsist)
                        File.Copy(q.FilePath, @"saving_quiz_temporary_foldr\" + filename);
                    else
                        MessageBox.Show("File: " + q.FilePath + " does not exsist, no multimedia added.", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning );
                }
            }

            var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("quiz", elements));
            document.Save(@"saving_quiz_temporary_foldr\control.xml");

            if (File.Exists(filePath))
                File.Delete(filePath);

            ZipFile.CreateFromDirectory(@"saving_quiz_temporary_foldr", filePath);

            if (Directory.Exists("saving_quiz_temporary_foldr"))
                Directory.Delete("saving_quiz_temporary_foldr", true);
        }

        public void SaveAsProject(string FilePath)
        {
            var elements = new List<XElement>();

            foreach (var q in questions)
            {
                var element = new XElement
                (
                    "entry",
                    new XElement("question", q.Question),
                    new XElement("ansA", q[0]),
                    new XElement("ansB", q[1]),
                    new XElement("ansC", q[2]),
                    new XElement("ansD", q[3]),
                    new XElement("right", q.RightAnswerIndex),
                    new XElement("multimedia", q.Multimedia),
                    new XElement("filepath", q.FilePath)
                );
                elements.Add(element);
            }

            var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("quiz", elements));
            document.Save(FilePath);
        }
    }
}
