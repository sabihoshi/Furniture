using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using Furniture.ViewModels.Materials;
using Furniture.ViewModels.Materials.Items;
using Furniture.ViewModels.Materials.Models;
using Furniture.ViewModels.Quotation;
using Wood = Furniture.ViewModels.Materials.Models.Wood;

namespace Furniture.Config
{
    public class Config
    {
        public List<int> Lengths { get; set; }

        public List<int> Widths { get; set; }

        public List<decimal> WoodValues { get; set; }

        public List<decimal> PieceValues { get; set; }

        public List<Wood> Woods { get; set; }

        public List<Piece> Pieces { get; set; }

        public List<ComboBoxItem<decimal>> Plywood { get; set; }

        public BindableCollection<Quotation> Work { get; set; }
    }
}