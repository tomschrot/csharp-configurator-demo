using System.Linq;
using System;

namespace test {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("C# Functional");
            Console.WriteLine("Configurator Demo");
            Console.WriteLine("(c) Tom Schröter\n");

            // In the common way, new objects are created imperative like this:
            // (no encapsulation at all!)
            var p1 = new Person();
            p1.firstname = "Donald";
            p1.lastname  = "Duck";
            p1.address   = "Speichergasse 13";
            p1.capitalize();
            // etc.

            // Using a object initialzer can be helpful.
            // But it does NOT allow access to ALL members of the object,
            // only the fields, and breakes the declarative context!
            var p2 = new Person { 
                            firstname = "Dagobert", // inside
                            lastname  = "Duck"    , // inside
                            address   = "Speicherberg 1"
                            // etc.
                    };
            p2.capitalize(); // outside

            // Instead of the object initializer, the functional approach
            // is more flexible. It allows access to all members during 
            // object creation and does not break encapsulation.
            // But it reqires a constructor that takes,
            // how I call it, a "configuration lambda" or configurator. 
            var p3 = new Person( my => {
                            my.firstname = "Dasy";
                            my.lastname  = "Duck";
                            my.address   = "Blumenweg 7";
                            my.capitalize();
                            // etc. Everything inside.
                    });

            // The functional approach is IMHO readable and elegant:
            var smartCitizens = 
                    new PersonList()
                        .add( p1 )
                        .add( person => { 
                                person.firstname = "Gustav"; 
                                person.lastname  = "Gans"; 
                                person.address   = "Kleeweg 4";
                                person.capitalize();
                        });

            smartCitizens += p2;
            smartCitizens += p3;

            smartCitizens += new Person( me => {
                                me.firstname = "Kater";
                                me.lastname  = "Karlo";
                                me.address   = "Festungsgraben 9";
                                me.capitalize();
            });

            Console.WriteLine( smartCitizens );
        }
    }
}
