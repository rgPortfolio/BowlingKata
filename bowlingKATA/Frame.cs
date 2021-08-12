namespace bowlingKATA {
  internal class Frame {
    internal int RollCount;
    internal bool CanPlay;
    internal int FirstBall = -1;
    internal int SecondBall = -1;

    internal int Score { get; set; }
    internal bool Spare { get; set; }
    internal bool Strike { get; set; }

    internal bool PlayerCanRoll() {
      if(FirstBall != -1 && SecondBall != -1) {
        RollCount = 1;
      }
      CanPlay = RollCount < 2;
      RollCount = RollCount + 1;

      return CanPlay;
    }

    internal void SetFirstBall(int pins) {
      FirstBall = pins;
    }

    internal void SetSecondBall(int pins) {
      SecondBall = pins;
    }
  }
}
