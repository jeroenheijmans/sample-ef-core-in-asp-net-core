namespace SampleAspNetWithEfCore
{
    public class Team
    {
        public const string DefaultTeamCode = "default";

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class TeamUser
    {
        public int TeamId { get; set; }
        public string UserName { get; set; }
    }

    public class Person
    {
        public Team Team { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public Pet Pet { get; set; }

        public bool IsArchived { get; set; }
    }

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Animal Animal { get; set; }
    }

    public enum Animal
    {
        Cat = 0,
        Dog,
        Parrot,
        Hamster,
    }
}
