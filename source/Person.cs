using System;

namespace test {
    
    public sealed class Person {

        //FIXME: For uniqueness, you may prefer a non generic delegate type!
        //FIXME: Instead of Action<Person>.
        public delegate void Utilize(Person p);

        public string firstname {get; set;} = "";
        public string lastname  {get; set;} = "";
        public string address   {get; set;} = "";

        public string asString => $"{firstname} {lastname}, {address}";

        public Person() {}
        
        public Person(Utilize config) => config(this);

        // FIXME: Sure, .NET Action type does the same job:
        // public Person( Action<Person> action) => action(this);

        public void capitalize() {
            firstname = this.firstname.ToUpper();
            lastname  = this.lastname .ToUpper();
            address   = this.address  .ToUpper();
        }

        override public string ToString() => asString;
    }
}