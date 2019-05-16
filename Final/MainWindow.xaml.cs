using Final.Models;
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

namespace Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // initializers
        int _userWin = 0, _cpuWin = 0, _bestUserWin = 0, _bestCpuWin = 0;
        String _cpu, _user, _result;
        int _shoot;
        Random r = new Random();

        private void rdlScissor_Checked(object sender, RoutedEventArgs e)
        {
            _shoot = 3;
        }

        private void rdlPaper_Checked(object sender, RoutedEventArgs e)
        {
            _shoot = 2;
        }

        private void rdlRock_Checked(object sender, RoutedEventArgs e)
        {
            _shoot = 1;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShoot_Click(object sender, RoutedEventArgs e)
        {

            // cpu selects random number between 1 and 3
            int _cpuShoot = r.Next(1, 4);

            // actions if user selects rock
            if (_shoot == 1)
            {
                _user = "Rock";
                userImage.Source = new BitmapImage(new Uri("/images/rock 2.png", UriKind.Relative));
            }
            // actions if user selects paper
            else if (_shoot == 2)
            {
                _user = "Paper";
                userImage.Source = new BitmapImage(new Uri("/images/paper 2.png", UriKind.Relative));
            }
            // actions for only situation left
            else
            {
                _user = "Scissors";
                userImage.Source = new BitmapImage(new Uri("/images/scissors 2.png", UriKind.Relative));
            }

            // actions if cpu selects rock
            if (_cpuShoot == 1)
            {
                _cpu = "Rock";
                cpuImage.Source = new BitmapImage(new Uri("/images/rock 1.png", UriKind.Relative));
            }
            // actions if cpu selects paper
            else if (_cpuShoot == 2)
            {
                _cpu = "Paper";
                cpuImage.Source = new BitmapImage(new Uri("/images/paper 1.png", UriKind.Relative));
            }
            // actions for only situation left
            else
            {
                _cpu = "Scissors";
                cpuImage.Source = new BitmapImage(new Uri("/images/scissors 1.png", UriKind.Relative));
            }

            // rock vs scissors = win
            if (_shoot == 1 && _cpuShoot == 3)
            {
                _result = "Win!";
                count1.Source = new BitmapImage(new Uri("/images/only.png", UriKind.Relative));
                _userWin++;
            }

            // scissors vs paper = win
            else if (_shoot == 3 && _cpuShoot == 2)
            {
                _result = "Win!";
                count1.Source = new BitmapImage(new Uri("/images/only.png", UriKind.Relative));
                _userWin++;
            }

            // paper vs rock = win
            else if (_shoot == 2 && _cpuShoot == 1)
            {
                _result = "Win!";
                count1.Source = new BitmapImage(new Uri("/images/only.png", UriKind.Relative));
                _userWin++;
            }

            // if both selections are egual = draw
            else if (_shoot == _cpuShoot)
            {
                _result = "Draw";
            }

            // any other situation = loss
            else
            {
                _result = "Lose";
                count2.Source = new BitmapImage(new Uri("/images/only.png", UriKind.Relative));
                _cpuWin++;
            }

            // winning twice adds to users best out of 3 wins and resets the score
            if (_userWin == 2)
            {
                _bestUserWin++;
                _userWin = 0;
                _cpuWin = 0;
                count2.Source = new BitmapImage(new Uri("", UriKind.Relative));
                count1.Source = new BitmapImage(new Uri("", UriKind.Relative));
            }

            // winning twice adds to users best out of 3 wins and resets the score
            if (_cpuWin == 2)
            {
                _bestCpuWin++;
                _userWin = 0;
                _cpuWin = 0;
                count1.Source = new BitmapImage(new Uri("", UriKind.Relative));
                count2.Source = new BitmapImage(new Uri("", UriKind.Relative));
            }

            // displays result of individual games
            lblResult.Content = _result;

            // displays best of 3 wins
            lblUserWins2.Content = _bestUserWin.ToString();
            lblcpuWins2.Content = _bestCpuWin.ToString();

            using (FormContext context = new FormContext())
            {
                try
                {
                    // adds info to database
                    Results r = new Results();
                    r.User = _user;
                    r.Cpu = _cpu;
                    r.Result = _result;
                    context.Result.Add(r);
                    context.SaveChanges();
                    //MessageBox.Show("Record added to DB.");
                }
                catch (Exception)
                {
                    //MessageBox.Show("Record failed to be added.");
                }
            }
        }
    }
}
