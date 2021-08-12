namespace bowlingKATA {
  internal class ScoreCalculation {
    internal static int STRIKE_OR_SPARE_SCORE = 10;
    internal static int MAX_GAME_SCORE = 300;
    internal static int PERFECT_FRAME_SCORE = 30;

    internal static int UpdateFrameScore(int ballOne, int ballTwo, int ballThree = 0) {
      return ballOne + ballTwo + ballThree;
    }

    internal static int CalculateSpareOrStrike(int currentScore, int ballAfterSpareOrStrike) {
      return currentScore + ballAfterSpareOrStrike;
    }
  }
}
