using bowlingKATA;
using NUnit.Framework;

namespace bowlingTests {
  [TestFixture]
  public class GameTests {
    private Game _game;
    [SetUp]
    public void Init() {
      _game = new Game();
    }
    [Test]
    public void GameScoreIsZeroAtStart() {
      Assert.AreEqual(0, _game.Score());
    }

    [Test]
    public void AfterFourRollsGameScoreIsCorrectValue() {
      _game.Roll(4);
      _game.Roll(4);
      _game.Roll(4);
      _game.Roll(4);

      Assert.AreEqual(16, _game.Score());
    }

    [Test]
    public void PlayerCanRoll() {
      Assert.IsTrue(_game.Frames[_game.Current].PlayerCanRoll());
    }

    [Test]
    public void AreThereTenFramesInAGame() {
      Assert.AreEqual(10, _game.Frames.Count);
    }

    [Test]
    public void RollingBallTwiceWillIncrementTheFrame() {
      _game.Roll(4);
      _game.Roll(4);

      Assert.AreEqual(1, _game.Current);
    }

    [Test]
    public void RollingBallTwiceWithTwoSetsCurrentFrameScoreToFour() {
      _game.Roll(2);
      _game.Roll(2);

      Assert.AreEqual(4, _game.Frames[_game.Current - 1].Score);
    }


    [Test]
    public void DoesGameKnowWhenItIsTenthFrame() {
      _game.Current += 9;

      Assert.IsTrue(_game.ItIsTenthFrame());
    }

    [Test]
    public void NextFrameKnowsIfPlayerRolledSpareLastFrame() {
      _game.Roll(3);
      _game.Roll(7);

      Assert.IsTrue(_game.Frames[_game.Current].Spare);
    }

    [Test]
    public void RollingFiveAfterSpareReturnsFifteen() {
      _game.Roll(5);
      _game.Roll(5);
      _game.Roll(5);

      Assert.AreEqual(15, _game.Frames[_game.Current - 1].Score);
    }

    [Test]
    public void NextFrameKnowsIfPlayerRolledStrikeLastFrame() {
      _game.Roll(10);
      Assert.IsTrue(_game.Frames[_game.Current].Strike);
    }

    [Test]
    public void RollingTwoBallsOfFourAndFiveAfterStrikeReturnsNineteen() {
      _game.Roll(10);
      _game.Roll(4);
      _game.Roll(5);

      Assert.AreEqual(19, _game.Frames[_game.Current - 2].Score);
    }

    [Test]
    public void RollingMultipleSparesInARowUsesSameArithmeticFromOneSpareRolled() {
      _game.Roll(7);
      _game.Roll(3);
      _game.Roll(5);
      _game.Roll(5);
      _game.Roll(4);

      Assert.AreEqual(15, _game.Frames[0].Score);
      Assert.AreEqual(14, _game.Frames[1].Score);
    }

    [Test]
    public void PlayerCannotRollIfTwoRollsHaveBeenMade() {
      _game.Frames[_game.Current].RollCount = 2;
      _game.Roll(4);

      Assert.IsFalse(_game.Frames[_game.Current].Score == 4);
    }

    [Test]
    public void ThreeStrikesInARowResultsInPerfectFrameForThrityPoints() {
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);

      Assert.AreEqual(30, _game.Frames[0].Score);
    }

    [Test]
    public void RollingThreeTotalBallsInTenthFrameIsAllowed() {
      _game.Current = 9;

      _game.Roll(5);
      _game.Roll(3);
      _game.Roll(1);

      Assert.AreEqual(9, _game.Frames[_game.Current].Score);
    }

    [Test]
    public void TenthFrameWithThreeStrikesIsPerfectFrameOfThirtyPoints() {
      _game.Current = 9;

      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);

      Assert.AreEqual(30, _game.Frames[_game.Current].Score);
    }

    [Test]
    public void CanWeHaveAPerfectGameWithTwelveStrikesAnd300Points() {
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);
      _game.Roll(10);

      Assert.IsTrue(_game.Score() == 300);
    }

    [Test]
    public void ScoringNormalInputsOfAGameWithSparesAndStrikesFor131Points() {

      _game.Roll(3);
      _game.Roll(6);

      _game.Roll(5);
      _game.Roll(4);

      _game.Roll(3);
      _game.Roll(7);

      _game.Roll(9);
      _game.Roll(1);

      _game.Roll(5);
      _game.Roll(5);

      _game.Roll(10);

      _game.Roll(4);
      _game.Roll(2);

      _game.Roll(10);

      _game.Roll(4);
      _game.Roll(2);

      _game.Roll(3);
      _game.Roll(7);
      _game.Roll(5);

      Assert.AreEqual(131, _game.Score());
    }
  }
}
