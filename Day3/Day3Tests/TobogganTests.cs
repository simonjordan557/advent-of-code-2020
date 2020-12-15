using NUnit.Framework;
using Day3Library;
using AdventOfCodeHelper;

namespace Day3Tests
{
    public class TobogganTests
    {
        Toboggan _toboggan;

        [SetUp]
        public void Setup()
        {
            _toboggan = new Toboggan(1, 1);
        }

        [Test]
        public void Toboggan_WhenConstructed_AssignsSlopeXCorrectly()
        {
            Assert.That(_toboggan.slopeX, Is.EqualTo(1));
        }

        [Test]
        public void Toboggan_WhenConstructed_AssignsSlopeYCorrectly()
        {
            Assert.That(_toboggan.slopeY, Is.EqualTo(1));
        }

        [Test]
        public void Toboggan_WhenMountainAdded_WorksAsExpected()
        {
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            Assert.That(_toboggan.mountain[4], Is.EqualTo(@"#..#..#..#"));
        }

        [Test]
        public void Toboggan_HowManyTreeStrikes_WorksAsExpected()
        {
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            _toboggan.mountain.Add(@"#..#..#..#");
            Assert.That(_toboggan.HowManyTreeStrikes(), Is.EqualTo(3));
        }
    }
}