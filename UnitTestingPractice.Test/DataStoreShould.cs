using Xunit;
using AutoFixture;
using Moq;

namespace UnitTestingPractice.Test
{
    public class DataStoreShould
    {
        private readonly string key;
        private readonly string data;
        private readonly IDataStore sut;

        public DataStoreShould()
        {
            var fixture = new Fixture();
            var logger = new Mock<ILogger>();

            key = null;
            data = fixture.Create<string>();
            sut = new DataStore(logger.Object);
        }

        [Theory]
        [AutoMoqData]
        public void CreateRecord(string data, string key, DataStore sut)
        {
            var createResult = sut.Create(key, data);
            Assert.True(createResult);

            var updateResult = sut.Update(key, data);
            Assert.True(updateResult);

            var readResult = sut.TryRead(key, out var readData);
            Assert.True(readResult);
            Assert.NotNull(readData);

            var deleteResult = sut.Delete(key);
            Assert.True(deleteResult);

        }

        [Fact]
        public void ReturnFalseInCreateWhenKeyIsNull()
        {

            var createResult = sut.Create(key, data);
            Assert.False(createResult);

        }

        [Fact]
        public void ReturnFalseInUpdateWhenKeyIsNull()
        {

            var updateResult = sut.Update(key, data);
            Assert.False(updateResult);

        }

        [Fact]
        public void ReturnFalseInUpdateWhenKeyNotFound()
        {
            var nonExistantkey = "NonExistantkey";

            var updateResult = sut.Update(nonExistantkey, data);
            Assert.False(updateResult);

        }

        [Fact]
        public void ReturnFalseInReadWhenKeyIsNull()
        {

            var readResult = sut.TryRead(key, out var readData);
            Assert.False(readResult);
            Assert.Null(readData);

        }

        [Fact]
        public void ReturnFalseInDeleteWhenKeyIsNull()
        {
            var deleteResult = sut.Delete(key);
            Assert.False(deleteResult);

        }

        [Fact]
        public void ReturnFalseInDeleteWhenKeyIsNonExistant()
        {
            var nonExistantKey = "NonExistantkey";
            var deleteResult = sut.Delete(nonExistantKey);
            Assert.False(deleteResult);

        }

    }
}
