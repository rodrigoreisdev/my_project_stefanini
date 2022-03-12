using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.ExampleAggregate
{
    public sealed class Person
    {
        private Person(string name_person, int age, string cpf)
        {
            this.name_person = name_person;
            this.age = age;
            this.cpf = cpf;
        }

        public int id { get; set; }
        public string name_person { get; set; }
        public string cpf { get; set; }
        public int age { get; set; }
        public City city { get; set; }
       

        public static Person Create(string name_person, int age,string cpf)
        {
            if (name_person == null) 
                throw new ArgumentException("Invalid " + nameof(name_person));

            if (age == 0)
                throw new ArgumentException("Invalid " + nameof(age));
            
            if(cpf == null)
                throw new ArgumentException("Invalid " + nameof(cpf));

            return new Person(name_person, age, cpf);
        }

        public void Update(string name_person, int age, string cpf)
        {
            if (name_person != null)
                this.name_person = name_person;

            if (age != 0)
                this.age = age;

            if (cpf != null)
                this.cpf = cpf;
        }
    }
}
