using PersonLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        PeopleRepository peopleRepo = new PeopleRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConcreteFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            //creating a list var
            List<Person> people;

            //get people array
            people = peopleRepo.GetPeople();
            PersonListBox.ItemsSource = people;
            //foreach(var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}
        }

        private void InterfaceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            // using abstraction to future proof
            IEnumerable<Person> people;           
            people = peopleRepo.GetPeople();
            PersonListBox.ItemsSource = people;
            //foreach(var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            //PersonListBox.Items.Clear();
            PersonListBox.ItemsSource = null;
        }
    }
}
