using System;

namespace HDAdvertising.Datas
{
    internal class DisplayTextAttribute : Attribute
    {
        string _text = "";
        public DisplayTextAttribute(string text)
        {
            _text = text;
        }

        public string Text => _text;
    }
}