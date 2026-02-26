namespace GraphSocialNetwork
{
    class Person
    {
        public string Name { get; set; }
        public List<Person> Friends = new List<Person>();
        public Person(string name)
        {
            Name = name;
        }
        public void AddFriend(Person friend)
        {
            if (!Friends.Contains(friend))
            {
                Friends.Add(friend);
                friend.Friends.Add(this);
            }
        }
    }
    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
        }
        public void AddFriend(Person friend1, Person friend2)
        {
            if (!(_members.Contains(friend1) && _members.Contains(friend2)))
            {
                Console.WriteLine($"Any of Friends {friend1.Name} {friend2.Name} are not on Social Platform");
            }
            else
            {
                if (!friend1.Friends.Contains(friend2))
                {
                    friend1.Friends.Add(friend2);
                    friend2.Friends.Add(friend1);
                }
            }
        }
        public void ShowNetwork()
        {
            foreach (var item in _members)
            {
                Console.Write(item.Name + " -> ");
                List<String> friends = new List<string>();
                foreach (var friend in item.Friends)
                {
                    friends.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(",", friends)}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();
            Person aman = new Person("Aman");
            Person bhaskar = new Person("Bhaskar");
            Person chetan = new Person("Chetan");
            Person divakar = new Person("Divakar");
            Person eena = new Person("Eena");
            network.AddMember(aman);
            network.AddMember(bhaskar);
            network.AddMember(chetan);
            network.AddMember(divakar);
            network.AddFriend(aman, bhaskar);
            network.AddFriend(aman, chetan);
            network.AddFriend(bhaskar, chetan);
            network.AddFriend(divakar, chetan);
            network.AddFriend(aman, eena);
            network.ShowNetwork();
        }
    }
}
