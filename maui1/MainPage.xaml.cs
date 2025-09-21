namespace storegg
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnProductClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductDetailPage());
        }
    }
}
