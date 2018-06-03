using System;

namespace NetChanger
{
    class Profile
    {
        private string name;

        public string Name {
            get { return name; }
            set {
                var v = value.Trim();
                if ( v.Length > 1 ) {
                    name = value;
                }
                else {
                    throw new NullReferenceException( "Name cannot be blank." );
                }
            }
        }

        public NetSettings Settings { get; set; }
    }
}
