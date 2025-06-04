using Storage.Models;

namespace Storage.Tests
{
    public class BoxTests
    {
        [Fact]
        public void ExpirationDate_Computed_From_ProductionDate()
        {
            var box = new Box
            {
                ProductionDate = new DateOnly(2025, 1, 1)
            };

            var expected = new DateOnly(2025, 4, 11); // +100 дней
            Assert.Equal(expected, box.ExpirationDate);
        }

        [Fact]
        public void ExpirationDate_Explicit_Value_Takes_Priority()
        {
            var box = new Box
            {
                ProductionDate = new DateOnly(2025, 1, 1),
                ExpirationDate = new DateOnly(2025, 2, 15)
            };

            Assert.Equal(new DateOnly(2025, 2, 15), box.ExpirationDate);
        }
    }
}