using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> RawProductList;

        public MainWindow()
        {
            InitializeComponent();

            LoadProducts();
            AddButtons("GetAll", GetAll_M, GetAll_S);
            AddButtons("Get names length", GetName_M, GetName_S);
            AddButtons("Get only name", GetOnlyName_M, GetOnlyName_S);
            AddButtons("GetID1", GetID1_M, GetID1_S);
            AddButtons("OrderByPrice", OrderByPrice_M, OrderByPrice_S);
            AddButtons("OrderByPriceAndName", OrderByCategoryAndName_M, OrderByCategoryAndName_S);

        }
        private void OrderByCategoryAndName_M(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> result = RawProductList.OrderByDescending(product => product.CategoryId).ThenBy(product => product.Price).Select(product => product);

            resultsDataGrid.ItemsSource = result;
        }

        private void OrderByCategoryAndName_S(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> result = from Product in RawProductList orderby Product.CategoryId, Product.Price select Product;

            resultsDataGrid.ItemsSource = result;
        }

        private void OrderByPrice_M(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> result = RawProductList.OrderByDescending(product => product.Price).Select(product =>  product);

            resultsDataGrid.ItemsSource = result;
        }

        private void OrderByPrice_S(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> result = from Product in RawProductList orderby   Product.Price select Product;

            resultsDataGrid.ItemsSource = result;
        }
        private void GetOnlyName_M(object sender, RoutedEventArgs e)
        {
            IEnumerable<ProductName> result = RawProductList.Select(product => new ProductName { Name = product.Name, Id = product.Id });

            resultsDataGrid.ItemsSource = result;
        }

        private void GetOnlyName_S(object sender, RoutedEventArgs e)
        {
            IEnumerable<ProductName> result = from Product in RawProductList select new ProductName { Name = Product.Name , Id = Product.Id};

            resultsDataGrid.ItemsSource = result;
        }

        private void GetName_M(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> result = RawProductList.Select(product => product.Name);
            List<string> nameList = result.ToList();

            resultsDataGrid.ItemsSource = nameList;
        }

        private void GetName_S(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> result = from Product in RawProductList select Product.Name;
            List<string> nameList = result.ToList();

            resultsDataGrid.ItemsSource = nameList;
        }



        private void GetAll_M(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> result = RawProductList.Select(product => product);
            resultsDataGrid.ItemsSource = result;
        }

        private void GetAll_S(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> result = from Product in RawProductList select Product;
            resultsDataGrid.ItemsSource = result;
        }

        private void GetID1_M(object sender, RoutedEventArgs e)
        {
            var result = RawProductList.Where(product => product.CategoryId == 1)
    .Select(product => new ProductName { Name = product.Name, Id = product.Id });
            resultsDataGrid.ItemsSource = result;
        }

        private void GetID1_S(object sender, RoutedEventArgs e)
        {
            IEnumerable<ProductName> result =from Product in RawProductList where Product.CategoryId == 1 select new ProductName { Name = Product.Name, Id = Product.Id };
            resultsDataGrid.ItemsSource = result;
        }

        public void LoadProducts()
        {
            string RawJSON = File.ReadAllText("Resources/Products.json");
            RawProductList = JsonSerializer.Deserialize<List<Product>>(RawJSON);
            
        }

        public void AddButtons(string MethodName,  RoutedEventHandler clickMethod, RoutedEventHandler clickSyntax)
        {
            StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

            Button buttonMethod = new Button
            {
                Margin = new Thickness(5),
                FontSize = 20,
                Content = $"{MethodName}+(M)"

            };
            buttonMethod.Click += clickMethod;
            Button buttonSyntax = new Button
            {
                Margin = new Thickness(5),
                FontSize = 20,
                Content = $"{MethodName}+(S)"

            };
            buttonSyntax.Click += clickSyntax;
            stackPanel.Children.Add(buttonMethod);
            stackPanel.Children.Add(buttonSyntax);
            buttonStack.Children.Add(stackPanel);
        }


    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public int CategoryId { get; set; }

    }

    public class ProductName
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
