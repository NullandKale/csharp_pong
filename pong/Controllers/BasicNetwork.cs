using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong.Controllers
{
    public class BasicNetwork : iController
    {
        private vector2 size;

        public BasicNetwork(vector2 gameBoardSize)
        {
            size = gameBoardSize;
        }

        public vector2 getMove(gameState state)
        {
            switch (state.outcome)
            {
                case lastMoveOutcome.good:
                    reward();
                    break;
                case lastMoveOutcome.neutral:
                    break;
                case lastMoveOutcome.bad:
                    punish();
                    break;
            }

            return new vector2();
        }

        private void punish()
        {

        }

        private void reward()
        {

        }

        private double[] normalize(vector2 toNormalize)
        {
            double[] f = new double[2];
            f[0] = (double)toNormalize.x / (double)size.x;
            f[1] = (double)toNormalize.y / (double)size.y;

            return f;
        }
    }
}

public class Network
{
    public int inputLayerSize = 2;
    public int outputLayerSize = 2;
    public int hiddenLayerSize = 5;

    public double[,] w1;
    public double[,] w2;
    public double[,] z2;
    public double[,] a2;
    public double[,] z3;

    private Random r;

    public Network(int seed)
    {
        r = new Random(seed);
        w1 = fillWithRandom(inputLayerSize, hiddenLayerSize);
        w2 = fillWithRandom(hiddenLayerSize, outputLayerSize);
    }

    public double[,] fillWithRandom(int x, int y)
    {
        double[,] toReturn = new double[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                toReturn[i, j] = r.NextDouble();
            }
        }

        return toReturn;
    }

    public double[,] forward(double[,] x)
    {
        z2 = MultiplyMatrix(x, w1);
        a2 = SigmoidMatrix(z2);
        z3 = MultiplyMatrix(a2, w2);
        return SigmoidMatrix(z3);
    }

    public double[,] MultiplyMatrix(double[,] a, double[,] b)
    {
        if (a.GetLength(1) == b.GetLength(0))
        {
            double[,] c = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < a.GetLength(1); k++) // OR k<b.GetLength(0)
                        c[i, j] = c[i, j] + a[i, k] * b[k, j];
                }
            }

            return c;
        }
        else
        {
            Console.WriteLine("\n Number of columns in First Matrix should be equal to Number of rows in Second Matrix.");
            Console.WriteLine("\n Please re-enter correct dimensions.");
            Environment.Exit(-1);
            return null;
        }
    }

    public double[,] SigmoidMatrix(double[,] a)
    {
        double[,] c = new double[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                c[i, j] = Sigmoid(a[i, j]);
            }
        }

        return c;
    }

    public double Sigmoid(double value)
    {
        double k = Math.Exp(value);
        return k / (1.0 + k);
    }
}