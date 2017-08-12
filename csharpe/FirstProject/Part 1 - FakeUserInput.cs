using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

/// <summary>
/// Math Calculator - Part 1  
/// </summary>
public static class FakeUserInput
{
    /* 
     * Purposefully made non-human readable because I don't want you to read it. And if you want to, you'll suffer. 
     */
    private static List<float> F;
    private static List<float> S;

    private static List<int> O;
    private static string[] Op = { "+", "-", "*", "/" };
    private static Func<float, float, float>[] Or; 
    private static List<float> E;

    private static int P;
    private static int C;

    static FakeUserInput()
    {
        P = -1;
        C = 0;

        int ET = 50; 
        F = new List<float>(ET);
        S = new List<float>(ET);
        O = new List<int>(ET); 
        E = new List<float>(ET);

        Or = new Func<float, float, float>[] { (f,s) => { return f + s; }, (f, s) => { return f - s; }, (f, s) => { return f * s; } , (f, s) => { return f / s; }}; 

        //Add Tests
        PopulatTests(2, 1);
        PopulatTests(1, 1);
        PopulatTests(1, -1);
        PopulatTests(-2, -1);
        PopulatTests(1, -1);
        PopulatTests(1.5f, 1);
        PopulatTests(-1.5f, 1);
        PopulatTests(-1, 2);
        PopulatTests(4, -2);
        PopulatTests(15, 4);
    }

    /// <summary>
    /// For me!!
    /// </summary>
    private static void AddTestSet(float f, float s, int o)
    {
        F.Add(f);
        S.Add(s);
        O.Add(o);

        E.Add(Or[o-1](f,s));
    }

    /// <summary>
    /// Because I can 
    /// </summary>
    private static void PopulatTests(float f, float s)
    {
        for (int i = 0; i < Op.Length; i++)
        {
            AddTestSet(f, s, i + 1);
            AddTestSet(s, f, i + 1);
        }
    }

    /// <summary>
    /// Give first input number 
    /// </summary>
    /// <returns></returns>
    public static float GetFirstNumber()
    {
        return F[P];
    }

    /// <summary>
    /// Gives second input  number
    /// </summary>
    /// <returns></returns>
    public static float GetSecondNumber()
    {
        return S[P];
    } 
    
    /// <summary>
    /// Gives second input  number
    /// </summary>
    /// <returns></returns>
    public static int GetOperation()
    {
        return O[P];
    }

    /// <summary>
    /// Validates your answer. 
    /// </summary>
    /// <param name="answer"></param>
    public static void ExpectedAnswer(float answer)
    {
        if (Math.Abs(answer - E[P]) > 0.001f)
        { 
            Debug.WriteLine("Program failed to calculate: \"{0} {1} {2} = {3}\", your answer: {4}", F[P], Op[O[P]-1], S[P], E[P], answer);
        }
        else
        {
            C++; 
        }
    }

    /// <summary>
    /// Indecates if there was more tests to run 
    /// </summary>
    /// <returns></returns>
    public static bool HasMore()
    {
        if(++P == O.Count)
        {
            Debug.WriteLine("Test ended. You got {0} answers correct out of {1}", C, F.Count);
            return false;

        }

        return true; 
    }

}

