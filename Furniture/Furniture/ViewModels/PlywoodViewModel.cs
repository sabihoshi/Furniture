﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Furniture.Caption;
using Furniture.Materials;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public sealed class PlywoodViewModel : MaterialModel
    {
        private readonly Plywood _plywood = App.Config.Plywood;

        public PlywoodViewModel(IParent parentModel) : base(parentModel)
        {
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateComboBox(nameof(Thickness), _plywood.Thicknesses, true);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity));

            Fields = new List<object>
            {
                Thickness, Quantity
            };
        }

        public override string Name => "Plywood";
        public Plywood Plywood { get; set; } = App.Config.Plywood;
        public CaptionViewModel<int> Quantity { get; }
        public CaptionViewModel<decimal> Thickness { get; }

        public override decimal Total { get; set; }

        public override decimal GetTotal()
        {
            return Thickness.TValue * Quantity.TValue;
        }
    }
}