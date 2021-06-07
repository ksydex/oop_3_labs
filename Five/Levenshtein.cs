using System;

namespace Five
{
    public static class Levenshtein
    {
        public static class WagnerFisher
        {
            public static double Distance(string s1, string s2, int limit)
            {
                if (s1 == null || s2 == null) throw new ArgumentNullException();
                if (s1 == s2) return 0;
                if (s1.Length == 0) return s2.Length;
                if (s2.Length == 0) return s1.Length;

                // предыдущий набор дистанций
                var v0 = new int[s2.Length + 1];
                // текущий набор дистанций
                var v1 = new int[s2.Length + 1];
                int[] vTemp;

                for (var i = 0; i < v0.Length; i++) v0[i] = i;

                for (var i = 0; i < s1.Length; i++)
                {
                    var minValue1 = v1[0] = i + 1;

                    // заполняем остальные дистанции по формуле
                    for (var j = 0; j < s2.Length; j++)
                    {
                        var cost = s1[i] == s2[j] ? 0 : 1;
                        v1[j + 1] = Math.Min(
                            v1[j] + 1, // Cost of insertion
                            Math.Min(
                                v0[j + 1] + 1, // цена удаления
                                v0[j] + cost)); // цена замены

                        minValue1 = Math.Min(minValue1, v1[j + 1]);
                    }

                    if (minValue1 >= limit)
                        return limit;
                    
                    // перемещаем рефы для след итерации
                    vTemp = v0;
                    v0 = v1;
                    v1 = vTemp;
                }

                return v0[s2.Length];
            }
        }
    }
}