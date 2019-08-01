using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Furniture.Properties;
using Furniture.Relationship;
using Furniture.ViewModels.Materials;
using Furniture.ViewModels.Materials.Items;
using Furniture.ViewModels.Materials.Models;
using Furniture.ViewModels.Quotation;

namespace Furniture.ViewModels
{
    public class TableViewModel : Parent
    {
        private readonly WindowManager _windowManager = new WindowManager();

        public BitmapImage Image { get; set; } = BitmapToImageSource(Properties.Resources.furniture);

        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public event WoodCreatedDelegate WoodCreated;

        public TableViewModel()
        {
            QuotationViewModel = new QuotationViewModel(this);
            AddItem();
        }

        public delegate void WoodCreatedDelegate(TableViewModel sender, Wood e);

        public BindableCollection<ItemViewModel> OrdersView { get; set; } = new BindableCollection<ItemViewModel>();

        public QuotationViewModel QuotationViewModel { get; set; }

        [UsedImplicitly]
        public void AddItem()
        {
            if (OrdersView.Count != 0 && OrdersView.Last().Content == null)
                return;
            OrdersView.Add(new ItemViewModel(this));
            OnPropertyChanged();
        }

        public void CreateMaterial()
        {
            if (GetView() is Window view)
            {
                var model = new NewWoodViewModel(this);

                view.Effect = new BlurEffect();
                view.Opacity = 0.5;

                _windowManager.ShowDialog(model);
            }
        }

        public decimal? GetTotal(MaterialBase.Material type)
        {
            var result = OrdersView.Where(x => x.Type == type).Sum(x => x.Content.Total);
            return result;
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            QuotationViewModel.OnPropertyChanged();
            base.OnPropertyChanged(propertyName);
        }

        public virtual void OnWoodCreated(Wood e)
        {
            WoodCreated?.Invoke(this, e);
            App.Config.Woods.Add(e);
            App.RewriteConfig();
        }

        public void RemoveItem(ItemViewModel itemViewModel)
        {
            OrdersView.Remove(itemViewModel);
            OnPropertyChanged(null);
        }

        [UsedImplicitly]
        public void ChangeImage(DragEventArgs e)
        {
            var fileList = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            if (fileList?.FirstOrDefault() != null)
            {
                Image = new BitmapImage(new Uri(fileList.First()));
            }
        }

        [UsedImplicitly]
        public void FilePreviewDragEnter(DragEventArgs e)
        {
            var dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                if (e.Data.GetData(DataFormats.FileDrop, true) is string[] filenames)
                {
                    var ext = Path.GetExtension(filenames[0])?.ToUpperInvariant();
                    if (ext != ".PNG" && ext != ".JPG" && ext != ".JPEG") dropEnabled = false;
                }
            }
            else { dropEnabled = false; }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }
    }
}