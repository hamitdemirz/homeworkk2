using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkk2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangi soruyu çözmek istersiniz?");
            Console.WriteLine("1 - Soru 1: 20 adet pozitif sayının asal ve asal olmayan olarak 2 ayrı listeye atanması.");
            Console.WriteLine("2 - Soru 2: 20 adet sayının en büyük 3 ve en küçük 3 sayısının bulunup ortalamalarının hesaplanması.");
            Console.WriteLine("3 - Soru 3: Girilen cümledeki sesli harflerin diziye atanması ve sıralanması.");
            Console.Write("Seçiminizi yapın (1/2/3): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SeparatePrimeAndNonPrime();
                    break;
                case "2":
                    FindMinMaxAndCalculateAverages();
                    break;
                case "3":
                    FindAndSortVowels();
                    break;
                default:
                    Console.WriteLine("Geçersiz bir seçim yaptınız.");
                    break;
            }
        }

        static void SeparatePrimeAndNonPrime()
        {
            ArrayList primeNumbers = new ArrayList();
            ArrayList nonPrimeNumbers = new ArrayList();

            int count = 0;
            while (count < 20)
            {
                Console.Write($"Sayı {count + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                {
                    if (IsPrime(number))
                        primeNumbers.Add(number);
                    else
                        nonPrimeNumbers.Add(number);

                    count++;
                }
                else
                {
                    Console.WriteLine("Geçersiz bir sayı girdiniz. Pozitif bir tam sayı girin.");
                }
            }

            Console.WriteLine("Asal Sayılar:");
            foreach (var prime in primeNumbers)
            {
                Console.WriteLine(prime);
            }

            Console.WriteLine("Asal Olmayan Sayılar:");
            foreach (var nonPrime in nonPrimeNumbers)
            {
                Console.WriteLine(nonPrime);
            }

            Console.WriteLine($"Asal Sayıların Sayısı: {primeNumbers.Count}");
            Console.WriteLine($"Asal Olmayan Sayıların Sayısı: {nonPrimeNumbers.Count}");
            if (primeNumbers.Count > 0)
                Console.WriteLine($"Asal Sayıların Ortalaması: {primeNumbers.Cast<int>().Average()}");
            if (nonPrimeNumbers.Count > 0)
                Console.WriteLine($"Asal Olmayan Sayıların Ortalaması: {nonPrimeNumbers.Cast<int>().Average()}");
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        static void FindMinMaxAndCalculateAverages()
        {
            int[] numbers = new int[20];
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"Sayı {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    numbers[i] = number;
                }
                else
                {
                    Console.WriteLine("Geçersiz bir sayı girdiniz. Lütfen tekrar deneyin.");
                    i--;
                }
            }

            Array.Sort(numbers);

            int min1 = numbers[0];
            int min2 = numbers[1];
            int min3 = numbers[2];

            int max1 = numbers[numbers.Length - 1];
            int max2 = numbers[numbers.Length - 2];
            int max3 = numbers[numbers.Length - 3];

            int minSum = min1 + min2 + min3;
            int maxSum = max1 + max2 + max3;

            double minAverage = CalculateAverage(minSum, 3);
            double maxAverage = CalculateAverage(maxSum, 3);

            Console.WriteLine($"En Küçük 3 Sayı: {min1}, {min2}, {min3}");
            Console.WriteLine($"En Büyük 3 Sayı: {max1}, {max2}, {max3}");
            Console.WriteLine($"En Küçük 3 Sayının Ortalaması: {minAverage}");
            Console.WriteLine($"En Büyük 3 Sayının Ortalaması: {maxAverage}");
            Console.WriteLine($"En Küçük 3 Sayıların Ortalamalarının Toplamı: {minSum}");
            Console.WriteLine($"En Büyük 3 Sayıların Ortalamalarının Toplamı: {maxSum}");
        }

        static double CalculateAverage(int sum, int count)
        {
            return (double)sum / count;
        }

        static void FindAndSortVowels()
        {
            Console.Write("Bir cümle girin: ");
            string sentence = Console.ReadLine();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            ArrayList vowelList = new ArrayList();

            foreach (char c in sentence)
            {
                if (Array.Exists(vowels, vowel => vowel == c))
                {
                    vowelList.Add(c);
                }
            }

            vowelList.Sort();

            Console.WriteLine("Sesli Harfler:");
            foreach (char vowel in vowelList)
            {
                Console.WriteLine(vowel);
            }
        }
      
    }
}
