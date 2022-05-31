using Kessewa.Quiz.Domain.Entities.Base;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Faculties : EntityBase
    {


        public string Name { get; private set; }
        public string Description { get; private set; }        
        
        private Faculties() { }

        private Faculties(string name)
        {
            Name = name;
        }

        public static Faculties Create(string name)
        {
            return new Faculties(name);
        }

        public Faculties SetId(int id)
        {
            Id = id;
            return this;
        }

        public Faculties WithName(string name)
        {
            Name = name;
            return this;
        }

        public Faculties WithDescription(string description)
        {
            Description = description;
            return this;
        }

        
    }
}