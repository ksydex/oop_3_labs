using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Five;
using Microsoft.Win32;

namespace Four
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HashSet<string> Data { get; set; }

        public bool DefaultAlgorithm { get; set; } = true;
        public bool WagnerFisher { get; set; }
        
        private const int MaxLimit = 5;
        
        public MainWindow()
        {
            InitializeComponent();
            Rb1.DataContext = this;
            Rb2.DataContext = this;
            ButtonSearch.IsEnabled = false;
        }

        private TimeSpan GetElapsedTime(Action func)
        {
            var timer = new Stopwatch();
            timer.Start();
            func.Invoke();
            timer.Stop();
            return timer.Elapsed;
        }

        private void ButtonBase_OpenFile(object sender, RoutedEventArgs e)
        {
            Data = new HashSet<string>();
            TextBoxSearch.Text = "";
            TextBoxElapsedTime.Text = "";
            TextBoxSearchElapsedTime.Text = "";
            
            var elapsedTime = GetElapsedTime(async () =>
            {
                var filePicker = new OpenFileDialog { DefaultExt = ".txt", Filter = "Текстовые файлы (*.txt)|*.txt" };
                var result = filePicker.ShowDialog();
                if (result != true) return;

                var content = await File.ReadAllTextAsync(filePicker.FileName);
                Data = content.Split("\n").ToHashSet();
            });
            ButtonSearch.IsEnabled = true;
            TextBoxElapsedTime.Text = "Время работы: " + elapsedTime;
        }

        private void ButtonBase_Search(object sender, RoutedEventArgs e)
        {
            var elapsedTime = GetElapsedTime(() =>
            {
                var query = TextBoxSearch.Text;
                var results = Data.Where(x => StringContains(x, query));
                ListBoxSearchResult.ItemsSource = results;
            });
            TextBoxSearchElapsedTime.Text = "Время поиска: " + elapsedTime;
        }

        private bool StringContains(string x, string substring)
            => DefaultAlgorithm
                ? x.Contains(substring)
                : Levenshtein.WagnerFisher.Distance(x, substring, MaxLimit) < MaxLimit;
    }
}