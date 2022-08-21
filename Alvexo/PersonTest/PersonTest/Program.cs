using System;
using System.Collections.Generic;

namespace PersonTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new PersonCollection();

            //collection.Add(new Person()); // need class supports inteface <Person>

            collection.onAdd += (object sender, CustomEventArgs e) => {
                Console.WriteLine("Added person with ID: "+ e.Person.getId()); 
            };

            collection.onRemove += (object sender, CustomEventArgs e) => {
                Console.WriteLine("Removed person with ID: "+ e.Person.getId()); 
            };
        }
    }

    public interface Person
    {
        public int getId();
        public String getFirstName();
        public String getLastName();
        public DateTime getDateOfBirth();
        public int getHeight();
        // etc… there may be more such get property methods

        public virtual int MaxValue {
            get {
                return getFirstName().Length + getLastName().Length + getHeight();
            }
        }
    }

    public class PersonCollection
    {
        private SortedList<int, Person> list { get; set; } = new SortedList<int, Person>();

        public event EventHandler<CustomEventArgs> onAdd;
        public event EventHandler<CustomEventArgs> onRemove;

        public void Add(Person person) {
            list.Add(person.MaxValue, person);

            RaiseAddEvent(new CustomEventArgs(person));
        }

        public Person Remove() {
            if (list.Count == 0) {
                return null;
            }

            var last = list[list.Count - 1];            
            list.Remove(last.MaxValue);

            RaiseRemoveEvent(new CustomEventArgs(last));

            return last;
        }

        protected virtual void RaiseAddEvent(CustomEventArgs e)
        {
            var raiseEvent = onAdd;
            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }

        protected virtual void RaiseRemoveEvent(CustomEventArgs e)
        {
            var raiseEvent = onRemove;
            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(Person person)
        {
            Person = person;
        }

        public Person Person { get; set; }
    }
}
