using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Quiz : IEnumerable<Question>
    {
        List<Question> questions;
        
        public Quiz()
        {
            questions = new List<Question>();
        }

        public void AddQuestion(Question q)
        {
            questions.Add(q);
        }

        public int Count
        {
            get { return questions.Count; }
        }

        public void Shuffle()
        {
            if (questions.Count == 0)
                return;

            Random r = new Random();

            for (int i = 0; i < 256; i++)
            {
                var i1 = r.Next(0, questions.Count);
                var i2 = r.Next(0, questions.Count);
                var tmp = questions[i1];
                questions[i1] = questions[i2];
                questions[i2] = tmp; 
            }
        }

        public void Clear()
        {
            foreach (var q in questions)
                if(q is ImageQuestion)
                    (q as ImageQuestion).Dispose();

            questions.Clear();
            GC.Collect();
        }

        public IEnumerator GetEnumerator()
        {
            return questions.GetEnumerator();
        }

        IEnumerator<Question> IEnumerable<Question>.GetEnumerator()
        {
            return ((IEnumerable<Question>)questions).GetEnumerator();
        }
    }
}
