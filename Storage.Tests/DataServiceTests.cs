using Storage.Services;
using System.IO;
using Xunit;

namespace Storage.Tests
{
    public class DataServiceTests
    {
        [Fact]
        public void LoadPallets_Returns_Data()
        {
            var service = new DataService();

            var pallets = service.LoadPallets();

            Assert.NotNull(pallets);
            Assert.NotEmpty(pallets); //Если есть json-файл по умолчанию
        }
    }
}