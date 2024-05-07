using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Common_Classes.Common_Elements
{
    /// <summary>
    /// Interaction logic for High_score.xaml
    /// </summary>
    public partial class High_score : Window
    {

        public High_score(Object high_scores_set)
        {
            HighScore_Set high_scores;
            HighScore_Set_Frogger high_scores_frogger;
            InitializeComponent();
            if (high_scores_set is HighScore_Set)
            {
                high_scores = (HighScore_Set)high_scores_set;
                Cards.Text = high_scores.card_Number.ToString();

                DataContext = high_scores;

                ObservableCollection<HighScore_Player> playerListBox = new ObservableCollection<HighScore_Player>();
                foreach (HighScore_Player player in high_scores.player_list)
                {
                    playerListBox.Add(player);
                }
                PlayerListBox.ItemsSource = playerListBox;
            }
            if (high_scores_set is HighScore_Set_Frogger)
            {
                high_scores_frogger = (HighScore_Set_Frogger)high_scores_set;
                Cards.Text = $"{high_scores_frogger.Difficalty.ToString()} Frogger";
                this.Width = 650;
                Card_s.Text = "";
                DataContext = high_scores_frogger;

                ObservableCollection<HighScore_Player> playerListBox = new ObservableCollection<HighScore_Player>();
                foreach (HighScore_Player player in high_scores_frogger.player_list)
                {
                    playerListBox.Add(player);
                }
                PlayerListBox.ItemsSource = playerListBox;
            }
        }

        private void Close_BT_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
