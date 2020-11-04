using System;
using System.Collections.Generic;
using System.Linq;

namespace TP_001_Codding
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Bonjour je m'appelle Constant et j'aime les carrés";

            int[] intTab = {6,4,5,1,-7,21};
            
            List<int> A = new List<int>(){1,4,5,7};
            
            List<int> B = new List<int>(){-2,4,6,8};
            
            List<int> C = new List<int>(){2,-32,0,5,7};
            
            //Test Question 1
            Console.WriteLine(StringListToString(ToList(str, 'a', "fin")));
            
            //Test Question 2
            Console.WriteLine(Reverse(str));
            
            //Test Question 3
            Console.WriteLine(WordsReversed(str));
            
            //Test Question 4
            Console.WriteLine((ReverseWords(str)));
            
            //Test Question 5
            Console.WriteLine(LowestIntIndex(intTab));
            
            //Test Question 6
            Console.WriteLine(IntTabToString(BubbleSort(intTab)));
            
            //Test Question 7
            Console.WriteLine(IntTabToString(InsertionSort(intTab)));
            
            //Test Question 8
            Console.WriteLine(IntListToString(Fusion(A, B)));
            
            //Test Question 9
            Console.WriteLine(IntListToString(TriFusion(C)));
        }
        
        //La fonction ToList() répond à la question 1
        static List<string> ToList(string chaine, char separator, string position)
        {
            List<string> list = new List<string>();
            string str = "";
            
            for (int i = 0; i < chaine.Length; i++)
            {
                if (chaine[i] == separator)
                {
                    if (position == "début") list.Insert(0, str);
                    else if (position == "fin") list.Add(str);
                    else Console.WriteLine("position argument needs to be début or fin");
                    str = "";
                }
                else
                {
                    str = str + chaine[i];
                }

            }

            if (position == "début") list.Insert(0, str);
            else if (position == "fin") list.Add(str);
            else Console.WriteLine("position argument needs to be début or fin");
            return list;
        }
        
        //la fonction Reverse répond à la question 2
        static string Reverse(string str)
        {
            List<char> listResult = new List<char>();
            
            for (int i = 0; i < str.Length; i++)
            {
                listResult.Insert(0, str[i]);
            }
            
            return CharListToString(listResult);
        }
        
        //la fonction WordsReversed répond à la question 3
        static string WordsReversed(string chaine)
        {
            List<string> liste = ToList(chaine, ' ',"fin");

            for (int i = 0; i < liste.Count; i++)
            {
                liste[i] = Reverse(liste[i]);
            }

            return StringListToString(liste, " ");
        }
        
        //la fonction ReverseWords répond à la question 4
        static string ReverseWords(string liste)
        {
            List<string> listResult = ToList(liste, ' ', "début");
            
            return StringListToString(listResult, " ");
        }
        
        //la fonction LowestIntIndex répond à la question 5

        static int LowestIntIndex(int[] inTab)
        {
            int result = 0;
            int lowest  = inTab[0];

            for (int i = 1; i < inTab.Length; i++)
            {
                if (inTab[i] < lowest)
                {
                    result = i;
                    lowest = inTab[i];
                }
            }
            
            return result;
        }

        //la fonction Switch2by2 répond à la question 6
        static int[] BubbleSort(int[] intTab)
        {
            int temp;
            
            for (int i = intTab.Length; i > 1; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (intTab[j] < intTab[j - 1])
                    {
                        temp = intTab[j - 1];
                        intTab[j - 1] = intTab[j];
                        intTab[j] = temp;
                    }
                }
            }

            return intTab;
        }
        
        //la fonction Insertion répond à la question 7
        static int[] InsertionSort(int[] intTab)
        {
            int temp;

            for (int i = 1; i < intTab.Length; i++)
            {
                temp = intTab[i];
                
                for (int j = i - 1; j >= 0; j--)
                {
                    if (intTab[j] > temp)
                    {
                        intTab[j + 1] = intTab[j];

                        intTab[j] = temp;
                    }
                }
            }

            return intTab;
        }
        
        //la fonction Fusion répond à la question 8
        static List<int> Fusion(List<int> A, List<int> B)
        {
            List<int> result = new List<int>();
            
            if (A.Count == 0) return B;
            
            if (B.Count == 0) return A;
            
            if (A[0] <= B[0])
            {
                result.Add(A[0]);
                result.AddRange(Fusion(A.GetRange(1, A.Count-1), B));
            }

            else
            {
                result.Add(B[0]);
                result.AddRange(Fusion(A, B.GetRange(1, B.Count-1)));
            }

            return result;
        }
        
        //la fonction TriFusion répond à la question 9
        static List<int> TriFusion(List<int> intList)
        {
            if (intList.Count <= 1)
            {
                return intList;
            }
            
            return Fusion(TriFusion(intList.GetRange(0, intList.Count / 2)),
                TriFusion(intList.GetRange(intList.Count / 2, intList.Count - intList.Count/2)));
        }
        
        //transforme une liste de string en string où chaque élément est séparé d'une string
        static string StringListToString(List<string> l, string joint = ", ")
        {
            string result = "";
            for (int i = 0; i < l.Count; i++)
            {
                result += l[i];
                result += i == l.Count - 1 ? "" : joint;
            }
            return result;
        }
        
        //transforme une liste de char en string;
        static string CharListToString(List<char> l)
        {
            string result = "";
            for (int i = 0; i < l.Count; i++)
            {
                result += l[i];
            }
            return result;
        }
        
        //transforme un tableau d'entiers en string où chaque élément est séparé d'une string
        static string IntTabToString(int[] intTab, string joint = ", ")
        {
            string result = "";
            for (int i = 0; i < intTab.Length; i++)
            {
                result += intTab[i];
                result += i == intTab.Length - 1 ? "" : joint;
            }
            return result;
        }

        //transforme une liste d'entiers en string où chaque élément est séparé d'une string
        static string IntListToString(List<int> intList, string joint = ", ")
        {
            string result = "";
            for (int i = 0; i < intList.Count; i++)
            {
                result += intList[i];
                result += i == intList.Count - 1 ? "" : joint;
            }
            return result;
        }
    }
}