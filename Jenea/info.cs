// https://stackoverflow.com/questions/1746501/can-someone-give-an-example-of-cosine-similarity-in-a-very-simple-graphical-wa

using System;

namespace CosineSimilarity
{
    class Program
    {
        static void Main()
        {
            int[] vecA = {1, 2, 3, 4, 5};
            int[] vecB = {6, 7, 7, 9, 10};

            var cosSimilarity = CalculateCosineSimilarity(vecA, vecB);

            Console.WriteLine(cosSimilarity);
            Console.Read();
        }

        private static double CalculateCosineSimilarity(int[] vecA, int[] vecB)
        {
            var dotProduct = DotProduct(vecA, vecB);
            var magnitudeOfA = Magnitude(vecA);
            var magnitudeOfB = Magnitude(vecB);

            return dotProduct/(magnitudeOfA*magnitudeOfB);
        }

        private static double DotProduct(int[] vecA, int[] vecB)
        {
            // I'm not validating inputs here for simplicity.            
            double dotProduct = 0;
            for (var i = 0; i < vecA.Length; i++)
            {
                dotProduct += (vecA[i] * vecB[i]);
            }

            return dotProduct;
        }

        // Magnitude of the vector is the square root of the dot product of the vector with itself.
        private static double Magnitude(int[] vector)
        {
            return Math.Sqrt(DotProduct(vector, vector));
        }
    }
}

/*
Let :
    a : [1, 1, 0]
    b : [1, 0, 1]
Then cosine similarity (Theta):

 (Theta) = (1*1 + 1*0 + 0*1)/sqrt((1^2 + 1^2))* sqrt((1^2 + 1^2)) = 1/2 = 0.5
then inverse of cos 0.5 is 60 degrees.*/
