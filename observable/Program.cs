using System.Collections.ObjectModel;

class Program
{
    class SortAge : IComparer<Person>  //вспомогательный класс, реализующий интерфейс Comparer для сортировки по полю Age
    {
        public int Compare(Person? per1, Person? per2)
        {
            if (per1?.Age > per2?.Age) return 1;

            if (per1?.Age < per2?.Age) return -1;

            return 0;
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine(Name + " " + Age);
        }


    }
    static void Main()
    {

        //применение класса ObservableCollection

        ObservableCollection<Person> collection = new ObservableCollection<Person>()
        {
            new Person("Jay", 18),
            new Person("Chuck", 22)
        };


        collection.CollectionChanged += people_collectionChanged;


        collection.Add(new Person("Max", 21));

        collection.RemoveAt(1);

        collection[0] = new Person("den", 21);



        Console.WriteLine("список обьектов");

        foreach (Person person in collection)
        {
            Console.WriteLine(person.Name);
        }

        static void people_collectionChanged(object sendler, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems[0] is Person newPerson)
                    {
                        Console.WriteLine($"добавлен обьект {newPerson.Name}");
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems[0] is Person oldPerson)
                    {
                        Console.WriteLine($"удален обьект {oldPerson.Name}");
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    if ((e.OldItems[0] is Person replacingPerson) &&
                        (e.NewItems[0] is Person replacedPerson))
                    {
                        Console.WriteLine($"обьект {replacingPerson.Name} заменен на {replacedPerson.Name}");
                    }
                    break;

            }
        }



    }
}