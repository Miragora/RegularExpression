using System;
using System.Text.RegularExpressions;


namespace RegularExpression
{
    class Program
    {
        static void Main()
        {
            var expr = new Regex(@"(8|\+7)(\d{3})(\d{3})(\d{2})(\d{2})"); //@ -чтобы слеш был слешем
            var str = @" Александр заригистрировался, указав телефон +79231234567 и электронную почту alexandr@server.ru; 
                      Мария указала электронную почту maria@mail.ru и телефон 89033217654.";
            //if(expr.IsMatch(str))
            //var all_matches = expr.Matches(str);
            foreach(Match match in expr.Matches(str))
            {
                Console.WriteLine("Телефон:{0} (положение:{1})",  //положение - это номер символа с которого начинается найденное совпадение
                match.Value, match.Index);


            }

            // выполним замену
            var str2 = expr.Replace(str, "+7($2)$3-$4-$5");
            Console.WriteLine(str2);
            var str3 = expr.Replace(str, match =>
            {
                if (match.Value.StartsWith("+7"))
                    return match.Value;
                return "+7(xxx) xxx - xx - xx";
            });
            Console.WriteLine(str3);

            Console.ReadLine();
        }
    }
}
