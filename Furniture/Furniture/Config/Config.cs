using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using Furniture.ViewModels.Materials.Models;
using Furniture.ViewModels.Quotation;

namespace Furniture.Config
{
    public class Config
    {
        public List<Cuboid> Cuboids { get; set; }

        public List<decimal> WoodValues { get; set; }

        public List<decimal> PieceValues { get; set; }

        public List<Wood> Woods { get; set; }

        public List<Piece> Pieces { get; set; }

        public List<ComboBoxItem<decimal>> Plywood { get; set; }

        public BindableCollection<Quotation> Work { get; set; }
    }
}