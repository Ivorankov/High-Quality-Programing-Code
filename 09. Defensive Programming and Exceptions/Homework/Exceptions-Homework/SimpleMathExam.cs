
using System;


public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 5;
    private const string GoodResultsComment = "Good result: all the problems are solved correctly.";
    private const string AverageResultsComment = "Average result: at least half the problems are solved correctly.";
    private const string BadResultsComment = "Bad result: only 1 problem solved - total fail.";
    private const int BadGradeMaxProblems = 1;
    private const int AverageGradeMaxProblems = 3;
    private const int GoodGradeMaxProblems = 5;
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            if (this.problemsSolved < SimpleMathExam.MinProblemsSolved)
            {
                return SimpleMathExam.MinProblemsSolved;
            }
            else if (this.problemsSolved > SimpleMathExam.MaxProblemsSolved)
            {
                return SimpleMathExam.MaxProblemsSolved;
            }
            else
            {
                return this.problemsSolved;
            }
        }

        set
        {
            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        string comment;

        if (this.ProblemsSolved <= SimpleMathExam.BadGradeMaxProblems)
        {
            comment = SimpleMathExam.BadResultsComment;
        }
        else if (this.ProblemsSolved <= SimpleMathExam.AverageGradeMaxProblems)
        {
            comment = SimpleMathExam.AverageResultsComment;
        }
        else 
        {
            comment = SimpleMathExam.GoodResultsComment;
        }

        return new ExamResult(this.ProblemsSolved, SimpleMathExam.MinProblemsSolved, SimpleMathExam.MaxProblemsSolved, comment);
    }
}


