
using System;

public class CSharpExam : Exam
{
    private const int MinValue = 0;
    private const int MaxValue = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        set
        {
            if (value < MinValue)
            {
                throw new ArgumentException("The score must be positive number");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.Score < MinValue || MaxValue < this.Score)
        {
            throw new InvalidOperationException("Exam result must be between 0 and 100");
        }
        else
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}

