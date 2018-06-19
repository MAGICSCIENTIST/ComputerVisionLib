using System;

namespace VisionLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ExNameAttribute : Attribute
    {
        private string[] _exNames;

        public string[] ExNames
        {
            get { return _exNames; }
        }
        public ExNameAttribute(params string[] exName)
        {
            this._exNames = exName;
        }





    }
}
