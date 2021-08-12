using bowlingKATA;
using NUnit.Framework;

namespace bowlingTests {
  [TestFixture]
  public class ScoreTests {
    [Test]
    public void IsMaxFrameScoreTen() {
      Assert.AreEqual(ScoreCalculation.STRIKE_OR_SPARE_SCORE, 10);
    }

    [Test]
    public void UpdateFrameScoreTakesTwoNumbersAndProducesCorrectResult() {
      Assert.AreEqual(9, ScoreCalculation.UpdateFrameScore(5, 4));
    }

    [Test]
    public void TenthFrameCanAdd3BallsForCorrectResult() {
      Assert.AreEqual(16, ScoreCalculation.UpdateFrameScore(5, 5, 6));
    }

    [Test]
    public void SpareAddsResultFromNextRollToItsCurrentScoreOfTen() {
      Assert.AreEqual(19, ScoreCalculation.CalculateSpareOrStrike(10, 9));
    }
  }
}
