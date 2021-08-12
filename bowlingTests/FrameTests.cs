using bowlingKATA;
using NUnit.Framework;

namespace bowlingTests {
  [TestFixture]
  public class FrameTests {
    private Frame _frame;

    [SetUp]
    public void Init() {
      _frame = new Frame();
      ;
    }

    [Test]
    public void FrameScoresStartAtNegativeOne() {
      Assert.AreEqual(-1, _frame.FirstBall);
      Assert.AreEqual(-1, _frame.SecondBall);
    }

    [Test]
    public void TotalFrameScoreIsZeroAtStart() {
      Assert.AreEqual(0, _frame.Score);
    }

    [Test]
    public void EachBowlingBallCanHaveAScore() {
      _frame.FirstBall = 4;
      _frame.SecondBall = 5;


      Assert.AreEqual(4, _frame.FirstBall);
      Assert.AreEqual(5, _frame.SecondBall);
    }

    [Test]
    public void FrameScoreIsEqualtoFirstBallPlusSecondBall() {
      _frame.FirstBall = 2;
      _frame.SecondBall = 8;

      _frame.Score = _frame.FirstBall + _frame.SecondBall;

      Assert.AreEqual(10, _frame.Score);
    }
  }
}

