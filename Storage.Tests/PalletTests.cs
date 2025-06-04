using Storage.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Storage.Tests
{
    public class PalletTests
    {
        [Fact]
        public void ExpirationDate_Returns_Min_Of_Boxes()
        {
            var pallet = new Pallet
            {
                Boxes = new List<Box>
                {
                    new Box { ExpirationDate = new DateOnly(2025, 12, 10) },
                    new Box { ExpirationDate = new DateOnly(2025, 10, 1) },
                    new Box { ExpirationDate = new DateOnly(2025, 11, 5) }
                }
            };

            Assert.Equal(new DateOnly(2025, 10, 1), pallet.ExpirationDate);
        }

        [Fact]
        public void Weight_Includes_Pallet_Weight()
        {
            var pallet = new Pallet
            {
                Boxes = new List<Box>
                {
                    new Box { Weight = 10 },
                    new Box { Weight = 5 }
                }
            };
            // Вес: паллеты = коробки + 30; коробоки = 10 + 5 = 15; Итог: 45
            Assert.Equal(45, pallet.Weight); 
        }

        [Fact]
        public void TotalPalletVolume_Is_Sum_Of_Self_And_Boxes()
        {
            var pallet = new Pallet
            {
                Width = 2,
                Height = 1,
                Depth = 1,
                Boxes = new List<Box>
                {
                    new Box { Width = 1, Height = 1, Depth = 1 },
                    new Box { Width = 0.5, Height = 1, Depth = 1 }
                }
            };

            // Обьем: паллеты = 2*1*1 = 2.0, коробок = 1 + 0.5 = 1.5
            Assert.Equal(3.5, pallet.TotalPalletVolume);
        }
    }
}