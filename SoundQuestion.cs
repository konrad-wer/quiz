using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Quiz
{
    class SoundQuestion : Question
    {
        SoundPlayer sound;
        public SoundQuestion(string question, string a, string b, string c, string d, int rightAnswer, SoundPlayer sound)
             : base(question, a, b, c, d, rightAnswer)
        {
            this.sound = sound;
        }

        public void Play()
        {
            sound.Play();
        }

        public void Stop()
        {
            sound.Stop();
        }
    }
}
