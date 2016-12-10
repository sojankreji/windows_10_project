using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSMART
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFile file;
        String ip = "";
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var args = e.Parameter as Windows.ApplicationModel.Activation.IActivatedEventArgs;
            if (args != null)
            {
                var fileargs = args as Windows.ApplicationModel.Activation.IFileActivatedEventArgs;
                String pathv = fileargs.Files[0].Path;
                file= (StorageFile)fileargs.Files[0];
                pathbox.Text = file.Path;
                
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile)
                {
                    ip = ip + line;
                }

            }
        }

        
  
    }

}
