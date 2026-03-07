namespace TheCargoManifestOptimizer
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }

    }
    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }
        public Container(string id, List<Item> item)
        {
            ContainerID = id;
            Items = item;
        }
    }
    public class CargoManifestOptimizer
    {
        private List<List<Container>> CargoBay;
        public CargoManifestOptimizer(List<List<Container>> cargoBay)
        {
            this.CargoBay = cargoBay;
        }
        //Task A:
        public List<String> FindHeavyContainers(double weightThreshold)
        {
            return CargoBay.SelectMany(r=>r).Where(c=>c.Items.Sum(i=>i.Weight)>weightThreshold).
                Select(c=>c.ContainerID).OrderBy(c=>c).ToList();
        }
        //Task B
        public Dictionary<string, int> GetItemCountsByCategory()
        {
            return CargoBay.Where(r=>r!=null).SelectMany(r=>r).SelectMany(c=>c.Items).GroupBy(i=>i.Category).
                ToDictionary(g=>g.Key, g=>g.Count());
        }
        public List<Item> FlattenAndSortShipment()
        {
            return CargoBay.Where(r => r != null).SelectMany(r => r).SelectMany(c => c.Items).
                GroupBy(i => i.Name).Select(g => g.First()).
                OrderBy(i => i.Category).ThenByDescending(i => i.Weight).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"), // Heavy Item
                        new Item("Cables", 1.2, "Tech")
                    })
                },
                // ROW 1: Mixed Consumer Goods
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },
                // ROW 2: Fragile & Perishables (Includes an Empty Container)
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
                },
                // ROW 3: EDGE CASE - Empty Row
                new List<Container>() // A row that exists but has no containers
            };
            var result = new CargoManifestOptimizer(cargoBay);
            Console.WriteLine("Heavy Weight Container");
            var heavyContainer = result.FindHeavyContainers(20);
            foreach (var item in heavyContainer)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Item Count by Weight");
            var ItemCount = result.GetItemCountsByCategory();
            foreach (var item in ItemCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine();
            Console.WriteLine("Flatten and Sort Shippment");
            var SortShippment = result.FlattenAndSortShipment();
            foreach (var item in SortShippment)
            {
                Console.WriteLine($"{item.Category} - {item.Name} - {item.Weight}");
            }
        }
    }
}
