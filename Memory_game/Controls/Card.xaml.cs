using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;

namespace Memory_game.Controls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card(Memory_Card card)
        {
            InitializeComponent();
            DataContext = card;

            Card_Button.Click += (sender, e) =>
            {
                card.Flip(sender, e);
            };
        }
    }
}
