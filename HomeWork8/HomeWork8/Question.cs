using System;

namespace HomeWork8
{
    [Serializable]
    public class Question
    {
        public string Text;
        public bool TrueFalse;
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }
    }
}
