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

namespace WPFNAME
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Contacts.Items.Add(new Contact() { Avatar = "avatar.png", Name = "Avatar Hemidov", Date = DateTime.Now.ToShortTimeString() });
            Contacts.Items.Add(new Contact() { Avatar = "avatar.png", Name = "Nicat Qara", Date = DateTime.Now.ToShortTimeString() });
            Contacts.Items.Add(new Contact() { Avatar = "avatar.png", Name = "Qabil Habilov", Date = DateTime.Now.ToShortTimeString() });
            Contacts.Items.Add(new Contact() { Avatar = "avatar.png", Name = "Rovshen Rzayev", Date = DateTime.Now.ToShortTimeString() });
            Contacts.Items.Add(new Contact() { Avatar = "avatar.png", Name = "Ramiz Agayev", Date = DateTime.Now.ToShortTimeString() });

            ContactNames = new string[5]
            {
                "Avatar Hemidov", "Nicat Qara", "Qabil Habilov", "Rovshen Rzayev", "Ramiz Agayev"
            };
            Name.Content = ContactNames[0];

        }

        public string[] ContactNames { get; set; }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(tbox.Text))
                {
                    if (MessageList1.Visibility == Visibility.Visible)
                    {
                        MessageList1.MesajYeri.Items.Add(new Message() { Date = DateTime.Now.ToShortTimeString(), Title = tbox.Text });
                        tbox.Clear();
                    }
                    else if (MessageList2.Visibility == Visibility.Visible)
                    {
                        MessageList2.MesajYeri.Items.Add(new Message() { Date = DateTime.Now.ToShortTimeString(), Title = tbox.Text });
                        tbox.Clear();
                    }
                    else if (MessageList3.Visibility == Visibility.Visible)
                    {
                        MessageList3.MesajYeri.Items.Add(new Message() { Date = DateTime.Now.ToShortTimeString(), Title = tbox.Text });
                        tbox.Clear();
                    }
                    else if (MessageList4.Visibility == Visibility.Visible)
                    {
                        MessageList4.MesajYeri.Items.Add(new Message() { Date = DateTime.Now.ToShortTimeString(), Title = tbox.Text });
                        tbox.Clear();
                    }
                    else if (MessageList5.Visibility == Visibility.Visible)
                    {
                        MessageList5.MesajYeri.Items.Add(new Message() { Date = DateTime.Now.ToShortTimeString(), Title = tbox.Text });
                        tbox.Clear();
                    }
                }
            }
        }

        private void Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Contacts.SelectedIndex == 0)
            {
                MessageList3.Visibility = Visibility.Hidden;
                MessageList2.Visibility = Visibility.Hidden;
                MessageList1.Visibility = Visibility.Visible;
                MessageList4.Visibility = Visibility.Hidden;
                MessageList5.Visibility = Visibility.Hidden;
            }
            else if (Contacts.SelectedIndex == 1)
            {
                MessageList3.Visibility = Visibility.Hidden;
                MessageList2.Visibility = Visibility.Visible;
                MessageList1.Visibility = Visibility.Hidden;
                MessageList4.Visibility = Visibility.Hidden;
                MessageList5.Visibility = Visibility.Hidden;
            }
            else if (Contacts.SelectedIndex == 2)
            {
                MessageList3.Visibility = Visibility.Visible;
                MessageList2.Visibility = Visibility.Hidden;
                MessageList1.Visibility = Visibility.Hidden;
                MessageList4.Visibility = Visibility.Hidden;
                MessageList5.Visibility = Visibility.Hidden;
            }
            else if (Contacts.SelectedIndex == 3)
            {
                MessageList3.Visibility = Visibility.Hidden;
                MessageList2.Visibility = Visibility.Hidden;
                MessageList1.Visibility = Visibility.Hidden;
                MessageList4.Visibility = Visibility.Visible;
                MessageList5.Visibility = Visibility.Hidden;
            }
            else if (Contacts.SelectedIndex == 4)
            {
                MessageList3.Visibility = Visibility.Hidden;
                MessageList2.Visibility = Visibility.Hidden;
                MessageList1.Visibility = Visibility.Hidden;
                MessageList4.Visibility = Visibility.Hidden;
                MessageList5.Visibility = Visibility.Visible;
            }
            Name.Content = ContactNames[Contacts.SelectedIndex];
        }

        private void TextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(Search.Text))
                {
                    for (int i = 0; i < ContactNames.Count(); i++)
                    {
                        if (ContactNames[i].ToUpper().Contains(Search.Text.ToUpper()))
                        {
                            Contacts.SelectedIndex = i;
                        }
                    }
                }
                Search.Clear();
            }
        }
    }

    public class Contact
    {
        public string Avatar { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }
    }


    public class Message
    {
        public string Title { get; set; }

        public string Date { get; set; }
    }
}
