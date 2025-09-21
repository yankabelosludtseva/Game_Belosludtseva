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
using System.Windows.Threading;

namespace пр_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5);
        public List<Classes.PersonInfo> Enemys = new List<Classes.PersonInfo>();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Classes.PersonInfo Enemy;
        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();
            Enemys.Add(new Classes.PersonInfo("Враг 1", 100, 20, 1, 15, 5, 20));
            Enemys.Add(new Classes.PersonInfo("Враг 2", 20, 5, 1, 5, 2, 5));
            Enemys.Add(new Classes.PersonInfo("Враг 3", 50, 3, 1, 10, 10, 15));
            dispatcherTimer.Tick += AttackPlayer;
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
            SelectEnemy();
        }
        public void UserInfoPlayer()
        {
            if (Player.Glasses > 100 * Player.Level)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Healht += 100;
                Player.Damage++;
                Player.Armor++;
            }
            playerHealht.Content = "Жизненные показатели: " + Player.Healht;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;
        }

        private void AAttackEnemy(object sender, MouseButtonEventArgs e)
        {
            Enemy.Healht -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));
            if (Enemy.Healht < 0)
            {
                Player.Glasses += Enemy.Glasses;
                Player.Money += Enemy.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                emptyHealht.Content = "Жизненные показатели: " + Enemy.Healht;
                emptyArmor.Content = "Броня: " + Enemy.Armor;
            }
        }
        private void AttackPlayer(object sender, System.EventArgs e)
        {
            Player.Healht -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
        }
        public void SelectEnemy()
        {
            int Id = new Random().Next(0, Enemys.Count);
            Enemy = new Classes.PersonInfo(
                Enemys[Id].Name,
                Enemys[Id].Healht,
                Enemys[Id].Armor,
                Enemys[Id].Level,
                Enemys[Id].Glasses,
                Enemys[Id].Money,
                Enemys[Id].Damage);
        }
    }
}
