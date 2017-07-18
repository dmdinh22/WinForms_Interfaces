using PersonRepository.Fake;
using PersonRepository.Interface;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        //overriding on startup
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            FakeRepository repository = new FakeRepository();
            SimpleContainer.MapInstance<IPersonRepository>(repository);
        }
    }
}
