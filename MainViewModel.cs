using Async.AsyncColections;
using GalaSoft.MvvmLight;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
public class MainViewModel : ViewModelBase
{

    public MainViewModel()
    {
        UrlByteCount = new NotifyTaskCompletion<int>(MyStaticService.CountBytesInUrlAsync("https://docs.microsoft.com/"));
        UsingEntity = new NotifyTaskCompletion<int>(MyStaticService.UsingEntity());

        ///commands
        MyAsyncCommand = new AsyncCommand<string>(Calculate, CanCalculate, null,true);

    }
    public NotifyTaskCompletion<int> UrlByteCount { get; private set; }
    public NotifyTaskCompletion<int> UsingEntity { get; private set; }

    //command
    public AsyncCommand<string> MyAsyncCommand { get; private set; }
     async Task Calculate(string parameter)
    {
        await MyStaticService.AddUsingEntity(new Blog { BlogId = 1, Name = "Nona", Posts = new List<Post> { new Post { Title = "pota", Content = "miky" } } });
        //return Task.Factory.StartNew(CalculateCore);
    }
    bool CanCalculate(object parameter)
    {
        //...
        return true;
    }
    void CalculateCore()
    {
        //...
    }
    //onproperty
    private ObservableCollection<string> _strings = new AsyncObservableCollection<string>();
    public ObservableCollection<string> Strings
    {
        get { return _strings; }
        set
        {
            _strings = value;
        }
    }

}