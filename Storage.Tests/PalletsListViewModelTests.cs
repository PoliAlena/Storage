using Storage.Models;
using Storage.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xunit;
using Xunit.Abstractions;

namespace Storage.Tests
{
    public class PalletsListViewModelTests
    {
        [Fact]
        public void Constructor_ShouldLoadPalletsFromService()
        {
            var viewModel = new PalletsListViewModel();
            var result = viewModel.Pallets;

            Assert.NotNull(result);
            Assert.True(result.Count > 0); // предполагаем, что в JSON есть хотя бы 1 паллета
        }

        [Fact]
        public void Constructor_ShouldPopulateTopThreePallets_Correctly()
        {
            var viewModel = new PalletsListViewModel();
            var top3 = viewModel.TopThreePallets;
            var allPallets = viewModel.Pallets
                .Where( p => p.ExpirationDate.HasValue)
                .OrderByDescending(p => p.ExpirationDate.Value)
                .Take(3)
                .ToList();

            Assert.NotNull(top3);
            Assert.True(top3.Count <= 3); //<= Так как может быть ситуация когда кол-во всех паллет меньше трех
            Assert.All(top3, item => Assert.Contains(item, allPallets));
        }

        [Fact]
        public void GroupAndSort_ShouldSortByExpirationAndWeight()
        {
            var viewModel = new PalletsListViewModel();
            var unsorted = viewModel.Pallets.ToList();

            viewModel.GroupAndSort();
            var sorted = viewModel.Pallets;

            Assert.True(sorted.SequenceEqual(
                sorted.OrderBy(p => p.ExpirationDate).ThenBy(p => p.Weight)
            ));
        }
    }
}