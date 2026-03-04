using GeometryShape;

namespace GeometryShapeTests
{
    public class RectangleTests
    {
        const double VALID_WIDTH_1 = 5;
        const double VALID_HEIGHT_1 = 3;

        const double VALID_WIDTH_2 = 7;
        const double VALID_HEIGHT_2 = 2;

        const double FLOAT_TEST_MARGIN = 0.3;

        [Fact]
        public void Constructor_SetsWidthAndHeight()
        {
            var rect = new Rectangle(VALID_WIDTH_1, VALID_HEIGHT_1);

            Assert.Equal(VALID_WIDTH_1, rect.Width);
            Assert.Equal(VALID_HEIGHT_1, rect.Height);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-5.5)]
        public void Width_SetInvalidValue_ThrowsArgumentException(double invalidWidth)
        {
            var rect = new Rectangle(VALID_WIDTH_1, VALID_HEIGHT_1);

            Assert.Throws<ArgumentException>(() => rect.Width = invalidWidth);
        }

        [Fact]
        public void Width_SetValidValue_UpdatesProperty()
        {
            var rect = new Rectangle(VALID_WIDTH_1, VALID_HEIGHT_1);

            rect.Width = VALID_WIDTH_2;

            Assert.Equal(VALID_WIDTH_2, rect.Width);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-5.5)]
        public void Height_SetInvalidValue_ThrowsArgumentException(double invalidHeight)
        {
            var rect = new Rectangle(VALID_WIDTH_1, VALID_HEIGHT_1);

            Assert.Throws<ArgumentException>(() => rect.Height = invalidHeight);
        }

        [Fact]
        public void Height_SetValidValue_UpdatesProperty()
        {
            var rect = new Rectangle(VALID_WIDTH_1, VALID_HEIGHT_1);

            rect.Height = VALID_HEIGHT_2;

            Assert.Equal(VALID_HEIGHT_2, rect.Height);
        }

        [Theory]
        [InlineData(VALID_WIDTH_1, VALID_HEIGHT_1)]
        [InlineData(VALID_WIDTH_2, VALID_HEIGHT_2)]
        [InlineData(VALID_WIDTH_1 + FLOAT_TEST_MARGIN, VALID_HEIGHT_1)]
        [InlineData(VALID_WIDTH_1, VALID_HEIGHT_1 + FLOAT_TEST_MARGIN)]
        [InlineData(VALID_WIDTH_1 + FLOAT_TEST_MARGIN, VALID_HEIGHT_1 + FLOAT_TEST_MARGIN)]
        public void Area_ReturnsCorrectValue(double width, double height)
        {
            var rect = new Rectangle(width, height);
            double expected_area = width * height;

            double area = rect.Area();

            Assert.Equal(expected_area, area);
        }

        [Theory]
        [InlineData(VALID_WIDTH_1, VALID_HEIGHT_1)]
        [InlineData(VALID_WIDTH_2, VALID_HEIGHT_2)]
        [InlineData(VALID_WIDTH_1 + FLOAT_TEST_MARGIN, VALID_HEIGHT_1)]
        [InlineData(VALID_WIDTH_1, VALID_HEIGHT_1 + FLOAT_TEST_MARGIN)]
        [InlineData(VALID_WIDTH_1 + FLOAT_TEST_MARGIN, VALID_HEIGHT_1 + FLOAT_TEST_MARGIN)]
        public void Perimeter_ReturnsCorrectValue(double width, double height)
        {
            var rect = new Rectangle(width, height);
            double expected_perimeter = 2 * width + 2 * height;

            double perimeter = rect.Perimeter();

            Assert.Equal(expected_perimeter, perimeter);
        }

        [Theory]
        [InlineData(VALID_WIDTH_1, VALID_HEIGHT_1)]
        [InlineData(VALID_WIDTH_2, VALID_HEIGHT_2)]
        [InlineData(VALID_WIDTH_1 + FLOAT_TEST_MARGIN, VALID_HEIGHT_1)]
        [InlineData(VALID_WIDTH_1, VALID_HEIGHT_1 + FLOAT_TEST_MARGIN)]
        [InlineData(VALID_WIDTH_1 + FLOAT_TEST_MARGIN, VALID_HEIGHT_1 + FLOAT_TEST_MARGIN)]
        public void ToString_ReturnsCorrectRepresentation(double width, double height)
        {
            var rect = new Rectangle(width, height);
            string expected_string = $"Rectangle({width}x{height})";

            string result = rect.ToString();

            Assert.Equal(expected_string, result);
        }
    }
}