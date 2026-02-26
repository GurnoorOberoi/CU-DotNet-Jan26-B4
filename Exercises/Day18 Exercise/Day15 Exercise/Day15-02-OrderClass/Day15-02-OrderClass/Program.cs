namespace Day15_02_OrderClass
{
    class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private bool _discountApplied;
        private DateTime _orderDate;
        private string _status;
        
        //default constructor
        public Order()
        {
            _orderDate = DateTime.Today;
            _status = "NEW";
            _totalAmount = 0;
            _discountApplied = false;

        }
        //parameterized 
        public Order(int orderId, string customerName)
        {
            this._orderId = orderId;
            this._customerName = customerName;
            _status = "NEW";
        }
        //properties
        public int OrderId
        {
            get { return _orderId; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _customerName = value;
                }
            }
        }
        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        //4. Instance Methods
        public void AddItem(decimal price)
        {
            if (price > 0)
            {
                _totalAmount += price;
            }
        }
        public void ApplyDiscount(decimal percentage)
        {
            if(!_discountApplied && percentage>=1 && percentage <=30)
            {
                decimal discount = _totalAmount *(percentage/100);
                _totalAmount -= discount;
                if (_totalAmount < 0) _totalAmount = 0;
                _discountApplied = true;
            }
            else
            {
                Console.WriteLine("Discount Already applied");
            }

        }
        public string GetOrderSummary()
        {
            Console.WriteLine("Order Processing Domain");
            Console.WriteLine();
            return $"Order ID : {_orderId}\n" +
                $"Coustomer : {_customerName}\n" +
                $"Total Amount : {_totalAmount}\n" +
                $"Status : {_status}"; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Order o = new Order(101, "Rahul ");
            o.AddItem(500);
            o.AddItem(300);
            o.ApplyDiscount(10);
            //o.ApplyDiscount(20);
            Console.WriteLine(o.GetOrderSummary());
        }
    }
}
