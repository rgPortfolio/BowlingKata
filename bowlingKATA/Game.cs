using System.Collections.Generic;

namespace bowlingKATA {
  public class Game {
    private int _score;
    private const int FRAME_COUNT = 10;
    internal int Current;
    internal List<Frame> Frames;

    internal Game() {
      _score = 0;
      Frames = new List<Frame>();
      for(var i = 0; i < FRAME_COUNT; i++) {
        Frames.Add(new Frame());
      }
    }

    public int Score() {
      _score = 0;
      foreach(var frame in Frames) {
        _score = _score + frame.Score;
      }
      return _score;
    }

    public void Roll(int numberOfPins) {

      if(Frames[Current].PlayerCanRoll()) {
        if(FirstBallIsNotSet(numberOfPins)) {
          return;
        }

        TenthFrameRoll(numberOfPins);

        SecondBallIsNotSet(numberOfPins);

        IfItIsTimeForNextFrame();
      }
    }

    private void TenthFrameRoll(int numberOfPins) {
      if(ItIsTenthFrame() && Frames[Current].SecondBall != -1 && Frames[Current].SecondBall != -1) {
        if(numberOfPins == ScoreCalculation.STRIKE_OR_SPARE_SCORE) {

          Frames[Current].Score = Frames[Current].Score + ScoreCalculation.STRIKE_OR_SPARE_SCORE;
        } else {
          Frames[Current].Score += numberOfPins;
        }
      }
    }

    private void IfItIsTimeForNextFrame() {
      if(Frames[Current].RollCount == 2) {
        UpdateCurrentFrame();
      }
    }

    private void SecondBallIsNotSet(int numberOfPins) {
      if(Frames[Current].SecondBall == -1) {
        Frames[Current].SecondBall = 0;
        Frames[Current].SetSecondBall(numberOfPins);
        Frames[Current].Score = ScoreCalculation.UpdateFrameScore(Frames[Current].FirstBall, Frames[Current].SecondBall);

        if(ItIsASpare() && !ItIsTenthFrame()) {
          Frames[Current + 1].Spare = true;
        }

        LastFrameHadStrike(numberOfPins);
        _score = _score + Frames[Current].Score;

      }
    }

    private bool FirstBallIsNotSet(int numberOfPins) {
      if(Frames[Current].FirstBall == -1) {
        Frames[Current].FirstBall = 0;
        Frames[Current].SetFirstBall(numberOfPins);
        LastFrameHadSpare(numberOfPins);

        var lastStrike = LastFrameHadStrike(numberOfPins);
        var currentStrike = CurrentFrameStrikeEarned();

        if(currentStrike && lastStrike) {
          Frames[Current - 2].Score = ScoreCalculation.PERFECT_FRAME_SCORE;
        }
        return true;
      }
      return false;
    }

    private void LastFrameHadSpare(int numberOfPins) {
      if(Frames[Current].Spare) {
        Frames[Current - 1].Score = ScoreCalculation.CalculateSpareOrStrike(Frames[Current - 1].Score, numberOfPins);
      }
    }

    private bool LastFrameHadStrike(int numberOfPins) {
      if(Frames[Current].Strike) {
        Frames[Current - 1].Score = ScoreCalculation.CalculateSpareOrStrike(Frames[Current - 1].Score, numberOfPins);
        return true;
      }
      return false;
    }

    private bool CurrentFrameStrikeEarned() {
      if(ItIsAStrike(Frames[Current].FirstBall)) {

        if(!ItIsTenthFrame()) {
          Frames[Current + 1].Strike = true;
          Frames[Current].Score = Frames[Current].Score + ScoreCalculation.STRIKE_OR_SPARE_SCORE;

          UpdateCurrentFrame();

          return true;
        }
      }
      return false;
    }

    internal void UpdateCurrentFrame() {
      if(Current < Frames.Count - 1) {
        Current = Current + 1;
      }
    }

    internal bool ItIsTenthFrame() {
      return Current == FRAME_COUNT - 1;
    }

    public bool ItIsASpare() {
      return Frames[Current].Score == ScoreCalculation.STRIKE_OR_SPARE_SCORE;
    }

    internal bool ItIsAStrike(int strike) {
      return strike == ScoreCalculation.STRIKE_OR_SPARE_SCORE;
    }
  }
}
