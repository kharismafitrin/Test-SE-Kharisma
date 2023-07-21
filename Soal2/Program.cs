using System;
using System.Linq;

class Soal2
{
    static int[] GetDenseRanking(int[] scores, int[] playerScores)
    {
        int[] denseRanking = new int[playerScores.Length];
        scores = scores.Distinct().ToArray();
        Array.Sort(scores, (a, b) => b.CompareTo(a));

        for (int i = 0; i < playerScores.Length; i++)
        {
            int playerScore = playerScores[i];
            int rank = Array.BinarySearch(scores, playerScore, Comparer<int>.Create((a, b) => b.CompareTo(a)));

            if (rank < 0)
            {
                rank = ~rank + 1;
            }
            else
            {
                // If the exact score is found, go to the last occurrence to handle equal scores
                rank = Array.LastIndexOf(scores, playerScore) + 1;
            }

            denseRanking[i] = rank;
        }

        return denseRanking;
    }

    static void Main(string[] args)
    {
        try
        {
            Console.Write("Jumlah pemain yang ikut serta: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Daftar Skor dari yang terbesar ke terkecil (pisah dgn spasi): ");
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.Write("Jumlah permainan yang diikuti GITS: ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Skor yang didapatkan GITS (pisahkan dengan spasi): ");
            int[] playerScores = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int[] denseRanking = GetDenseRanking(scores, playerScores);

            Console.WriteLine("Hasil Dense Ranking untuk GITS:");
            Console.WriteLine(string.Join(" ", denseRanking));
        }
        catch (FormatException)
        {
            Console.WriteLine("Masukkan harus berupa bilangan bulat.");
        }
    }
}
