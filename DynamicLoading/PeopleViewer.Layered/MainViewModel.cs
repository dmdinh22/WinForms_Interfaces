using PersonRepository.Interface;
using System.Collections.Generic;
using System.ComponentModel;

namespace PeopleViewer
{
    //Boilerplate interface for WinForms
    public class MainViewModel : INotifyPropertyChanged
    {
        //internally used for VM
        private IPersonRepository repository;

        private IEnumerable<Person> people;

        //Data Binding to List Box in UI
        public IEnumerable<Person> People
        {
            get { return people; }
            set
            {
                people = value;
                RaisePropertyChanged("People");
            }
        } //People

        //Looks at Internal Repo, calls GetType method, returns string
        public string RepositoryType
        {
            get { return repository.GetType().ToString(); }
        } //RepositoryType

        // constructor
        public MainViewModel()
        {
            repository = RepositoryFactory.GetRepository();
        } //MainViewModel

        // access repo & call GetPeople method
        public void FetchData()
        {
            People = repository.GetPeople();
        } //FetchData

        public void ClearData()
        {
            // setting to empty list
            People = new List<Person>();
        } //ClearData

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
