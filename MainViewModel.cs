public class MainViewModel
{
    public MainViewModel()
    {
        UrlByteCount = new NotifyTaskCompletion<int>(
        MyStaticService.CountBytesInUrlAsync("http://www.example.com"));
    }
    public NotifyTaskCompletion<int> UrlByteCount { get; private set; }
}