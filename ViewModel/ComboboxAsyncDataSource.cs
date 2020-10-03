using Async.AsyncColections;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace Async.ViewModel
{
    public class ComboboxAsyncDataSource : ViewModelBase, INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members  
        public new event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string txt)
        {

            PropertyChangedEventHandler handle = PropertyChanged;
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(txt));
            }
        }

        private ComboData _typeGender;
        public ComboData TypeGender 
        { 
            get => _typeGender; 
            set => _typeGender = value; }

        #endregion
        public List<ComboData> TypesGenders
        {
            get
            {
                Thread.Sleep(500);
                List<ComboData> ListData = new List<ComboData>();
                ListData.Add(new ComboData { Id = "1", Value = "One" });
                ListData.Add(new ComboData { Id = "2", Value = "Two" });
                ListData.Add(new ComboData { Id = "3", Value = "Three" });
                ListData.Add(new ComboData { Id = "4", Value = "Four" });
                ListData.Add(new ComboData { Id = "5", Value = "Five" });

                ConectionEF();
                return ListData;
            }
        }

        private void ConectionEF() 
        {
            using (var context = new BloggingContext())
            {
                context.Blogs.Add(new Blog { BlogId = 1, Name = "Nona", Posts = new List<Post> { new Post { Title = "pota", Content = "miky" } } });
                context.SaveChanges();
                
            }
        }

        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string address;
        public string Address
        {
            get
            {
                Thread.Sleep(5000);
                return address;
            }
            set
            {
                Thread.Sleep(5000);
                address = value;
                OnPropertyChanged("Address");
            }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }


        private void ThisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FirstName = "Ryan";
            Address = "USA";
            Phone = "4563525234523";
        }

        public class ComboData
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }
    }
}