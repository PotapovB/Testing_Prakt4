using GeometryShape;

namespace GeometryShapeTests
{
    public class TriangleTests
    {
        // Египетский треугольник 3x4x5
        const double VALID_SIDE_A_1 = 3;
        const double VALID_SIDE_B_1 = 4;
        const double VALID_SIDE_C_1 = 5;

        // Равносторонний треугольник 5x5x5
        const double VALID_SIDE_A_2 = 5;

        // Равнобедренный треугольник 4x2x2
        const double VALID_SIDE_A_3 = 4; // (основание)
        const double VALID_SIDE_BC_3 = 3;

        [Fact]
        public void Properties_Get_ReturnCorrectValues()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Equal(VALID_SIDE_A_1, triangle.SideA);
            Assert.Equal(VALID_SIDE_B_1, triangle.SideB);
            Assert.Equal(VALID_SIDE_C_1, triangle.SideC);
        }

        [Theory]
        [InlineData(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1)]
        [InlineData(VALID_SIDE_A_2, VALID_SIDE_A_2, VALID_SIDE_A_2)]
        [InlineData(VALID_SIDE_A_3, VALID_SIDE_BC_3, VALID_SIDE_BC_3)]
        public void ToString_ReturnsCorrectRepresentation(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            string expected_string = $"Triangle({a}, {b}, {c})";

            string result = triangle.ToString();

            Assert.Equal(expected_string, result);
        }

        [Fact]
        public void SideA_SetValidValue_UpdatesProperty()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle.SideA = 6;

            Assert.Equal(6, triangle.SideA);
        }

        [Fact]
        public void SideA_SetInvalidValue_ThrowsArgumentExceptionAndDoesNotChange()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideA = VALID_SIDE_A_1 * 10); // 30,4,5 — невалидно (4+5<30)
            Assert.Equal(VALID_SIDE_A_1, triangle.SideA); // значение не должно измениться
        }

        [Fact]
        public void SideA_SetNegativeValue_ThrowsArgumentException()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideA = -VALID_SIDE_A_1);
        }

        [Fact]
        public void SideB_SetValidValue_UpdatesProperty()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            triangle.SideB = 5; // 6,5,5 — валидно

            Assert.Equal(5, triangle.SideB);
        }

        [Fact]
        public void SideB_SetInvalidValue_ThrowsArgumentExceptionAndDoesNotChange()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideB = 1); // 3,1,5 — невалидно (3+1<5)
            Assert.Equal(VALID_SIDE_B_1, triangle.SideB);
        }

        [Fact]
        public void SideB_SetNegativeValue_ThrowsArgumentException()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideB = -VALID_SIDE_B_1);
        }

        [Fact]
        public void SideC_SetValidValue_UpdatesProperty()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            triangle.SideC = 6; // 3,4,6 — валидно

            Assert.Equal(6, triangle.SideC);
        }

        [Fact]
        public void SideC_SetInvalidValue_ThrowsArgumentExceptionAndDoesNotChange()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideC = 8); // 3,4,8 — невалидно (3+4<8)
            Assert.Equal(VALID_SIDE_C_1, triangle.SideC);
        }

        [Fact]
        public void SideC_SetNegativeValue_ThrowsArgumentException()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideC = -VALID_SIDE_C_1);
        }

        [Fact]
        public void SettingSideToSumOfOtherTwo_ThrowsArgumentException()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            Assert.Throws<ArgumentException>(() => triangle.SideC = 7); // 3+4 == 7 — нестрогое неравенство (тоже не валидно)
        }

        [Fact]
        public void SetSide_DoesNotAffectOtherSides()
        {
            var triangle = new Triangle(VALID_SIDE_A_1, VALID_SIDE_B_1, VALID_SIDE_C_1);

            triangle.SideA = 4;

            Assert.Equal(VALID_SIDE_B_1, triangle.SideA);
            Assert.Equal(4, triangle.SideB);
            Assert.Equal(VALID_SIDE_C_1, triangle.SideC);
        }
    }
}

