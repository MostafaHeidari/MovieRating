using Moq;
using MovieRatingExample.Application;
using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;

namespace XUnitTestProject
{
    public class ReviewServiceTest
    {
        static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRates_TestCases()
        {
            // No Higest top-rate => empty List
            yield return new object[]
            {
                new BEReview[]
                {
                    new BEReview() {Reviewer = 1, Movie = 1, Grade = 4, ReviewDate = new DateTime() }
                },
                new List<int>()
            };
            // 1 highest top-rate => list(1)
            yield return new object[]
            {
                new BEReview[]
                {
                  new BEReview() {Reviewer = 1, Movie = 1, Grade = 4, ReviewDate = new DateTime() }
                }
            };
        }

        [Fact]
        public void CreateReviewServiceWithRepository()
        {
            // Arrange
            Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
            IReviewRepository repository = mockRepository.Object;

            // Act
            IReviewService service = new ReviewService(repository);

            // Assert
            Assert.NotNull(service);
            Assert.True(service is ReviewService);
        }

        [Fact]
        public void CreateReviewServiceWithNoRepositoryExceptArgumentException()
        {
            // Arrange
            IReviewService service = null;

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(() => service = new ReviewService(null));

            Assert.Equal("Missing repository", ex.Message);
            Assert.Null(service);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 0)]
        public void GetNumberOfReviewsFromReviewer(int reviewer, int expectedResult)
        {
            // Arrange
            BEReview[] fakeRepo = new BEReview[]
            {
                new BEReview() {Reviewer = 1, Movie = 1, Grade=3, ReviewDate = new DateTime()},
                new BEReview() {Reviewer = 2, Movie = 1, Grade=3, ReviewDate = new DateTime()},
                new BEReview() {Reviewer = 1, Movie = 2, Grade=3, ReviewDate = new DateTime()},
            };

            Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
            mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);

            IReviewService service = new ReviewService(mockRepository.Object);

            // Act
            int result = service.GetNumberOfReviewsFromReviewer(reviewer);

            // Assert
            Assert.Equal(expectedResult, result);
            mockRepository.Verify(r => r.GetAll(), Times.Once);
        }


        static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRates_TestCases()
        {
            // No Higest top-rate => empty List
            yield return new object[]
        }
        public void GetAverageRateFromReviewer(int movie)
        {
            // Arrange
            BEReview[] fakeRepo = new BEReview[]
            {
                new BEReview() {Reviewer = 1, Movie = 1, Grade=3, ReviewDate = new DateTime()},
                new BEReview() {Reviewer = 2, Movie = 1, Grade=3, ReviewDate = new DateTime()},
            };

            Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
            mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);

            IReviewService service = new ReviewService(mockRepository.Object);

            //Act
            int result = service.GetAverageRateFromReviewer(movie);


            //Assert


        }


        [Theory]
        [InlineData(1.2, 1)]
        [InlineData(2, 1.2)]
        public void GetAverageRateFromReviewer(int movie)
        {
            // Arrange
            BEReview[] fakeRepo = new BEReview[]
            {
                new BEReview() {Reviewer = 1, Movie = 1, Grade=3, ReviewDate = new DateTime()},
                new BEReview() {Reviewer = 2, Movie = 1, Grade=3, ReviewDate = new DateTime()},
            };

            Mock<IReviewRepository> mockRepository = new Mock<IReviewRepository>();
            mockRepository.Setup(r => r.GetAll()).Returns(fakeRepo);

            IReviewService service = new ReviewService(mockRepository.Object);

            //Act
            int result = (int)service.GetAverageRateFromReviewer(movie);


            //Assert


        }

        */
    }
}
