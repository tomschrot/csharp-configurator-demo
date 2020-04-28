using System;
using System.Text;
using System.Collections.ObjectModel;

namespace test {

    public sealed class PersonList {

        public static PersonList operator + (PersonList plist, Person p) {
            plist.list.Add(p);
            return plist;
        }

        public readonly Collection<Person> list = new Collection<Person>();
        
        public PersonList add( Person p)               => (this + p);
        public PersonList add( Person.Utilize config ) => (this + new Person(config));

        override public string ToString() {
            var sb = new StringBuilder();
            foreach(var p in list)
                sb.Append($"{p}\n");
            return sb.ToString();
        }
    }
}