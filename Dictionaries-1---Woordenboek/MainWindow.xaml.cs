using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionaries_1___Woordenboek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> _words = new Dictionary<string, string>();
        private readonly object explanationInputTextBox;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //if(String.IsNullOrWhiteSpace(wordTextBox.Text))
            //{
            //    wordTextBox.Background = Brushes.Red;
            //    return;
            //}
            //if (String.IsNullOrWhiteSpace(meaningTextBox.Text))
            //{
            //    meaningTextBox.Background = Brushes.Red;
            //    return;
            //}
            wordTextBox.Background = string.IsNullOrWhiteSpace(wordTextBox.Text) ? Brushes.Red : Brushes.White;
            meaningTextBox.Background = string.IsNullOrWhiteSpace(meaningTextBox.Text) ? Brushes.Red : Brushes.White;

            if (!string.IsNullOrWhiteSpace(wordTextBox.Text) && !string.IsNullOrWhiteSpace(meaningTextBox.Text))
            {
                wordTextBox.Background = Brushes.White;
                meaningTextBox.Background = Brushes.White;

                if (!_words.ContainsKey(wordTextBox.Text))
                {
                    _words.Add(wordTextBox.Text, meaningTextBox.Text);
                    //ToonLijst();
                    wordsListBox.Items.Add(wordTextBox.Text);
                    wordTextBox.Clear();
                    meaningTextBox.Clear();
                }
                else if (MessageBox.Show("Woord bestaat al!", "Oeps", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    _words[wordTextBox.Text] = meaningTextBox.Text;
                    wordTextBox.Clear();
                    meaningTextBox.Clear();
                }
            }
        }

        //private void ShowList()
        //{
        //    wordsListBox.Items.Clear();
        //    foreach (string word in _words.Keys)
        //    {
        //        wordsListBox.Items.Add(word);
        //    }
        //}

        private void wordsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (wordsListBox.SelectedItem != null)
                explanationTextBox.Text = _words[wordsListBox.SelectedItem.ToString()];
        }
    }
}
