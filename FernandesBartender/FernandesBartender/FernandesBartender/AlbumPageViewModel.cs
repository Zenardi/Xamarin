using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace FernandesBartender
{
    class AlbumPageViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (value != _text)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> PhotoList { get; set; }

        private int _currentPhoto;
        public int CurrentPhoto
        {
            get { return _currentPhoto; }
            set
            {
                if (value != _currentPhoto)
                {
                    _currentPhoto = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CurrentPhotoChangedCommand { get { return new Command<int>(i => CurrentPhoto = i + 1); } }
        public AlbumPageViewModel()
        {
            PhotoList = new ObservableCollection<string>();

            /*Title = "KLOOF ROAD HOUSE";
            Text = "Located at the foot of a nature reserve in Bedfordview, Johannesburg, Kloof Road House is the latest project by Nico van der Meulen Architects. " +
                   "The client's brief called for a family orientated home suitable for indoor/outdoor entertainment that maximizes the views to the north. " +
                   "The result is a 1100m² sculptural piece of architecture that is an extreme transformation from the previously modest single story. " +
                   "With every room in the house opening outdoors, linking the home with the landscaped garden, indoor/ outdoor living is guaranteed. " +
                   "Werner van der Meulen used morphed steels forms that wrap around and frame the structure by the use of parasitic architecture. " +
                   "From the street, the boldly designed off-shutter boundary wall with black steel shapes creeping over predicts that this is no ordinary piece of architecture.";
            */
            GetPhotos();
        }

        private void GetPhotos()
        {/*
            using (var client = new System.Net.Http.HttpClient())
            {
                for (int i = 1; i <= 45; i++)
                {
                    var image = string.Empty;

                    if (i < 10)
                        image = "https://image.architonic.com/imgArc/project-1/4/5205178/kloof-rd-by-nico-van-der-meulen-architects-0" + i + ".jpg";
                    else
                        image = "https://image.architonic.com/imgArc/project-1/4/5205178/kloof-rd-by-nico-van-der-meulen-architects-" + i + ".jpg";

                    //Check if the image exist
                    //var exist = await client.SendRequestAsync(new HttpRequestMessage(HttpMethod.Head, new System.Uri(image)));
                    //if (exist.IsSuccessStatusCode)
                    PhotoList.Add(image);
                }
            }*/

            PhotoList.Add("album/fotoalbum0.jpg");
            PhotoList.Add("album/fotoalbum1.jpg");
            PhotoList.Add("album/fotoalbum2.jpg");
            PhotoList.Add("album/fotoalbum3.jpg");
            PhotoList.Add("album/fotoalbum4.jpg");
            PhotoList.Add("album/fotoalbum5.jpg");
            PhotoList.Add("album/fotoalbum6.jpg");
            PhotoList.Add("album/fotoalbum7.jpg");
            PhotoList.Add("album/fotoalbum8.jpg");
            PhotoList.Add("album/fotoalbum9.jpg");


            //PhotoList.Add("https://imagesapt.apontador-assets.com/fit-in/640x480/4d689d72dc1c41c5947be7866d68b18a/drinks-bartender.jpg");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
