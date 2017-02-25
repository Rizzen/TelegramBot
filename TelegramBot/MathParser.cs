using System;
using System.Collections.Generic;

// TODO: нужен рефакторинг этого дерьма из книги
namespace TelegramBot
{
    class ParserException : ApplicationException
    {
        public ParserException(string str) : base(str) { }

        public override string ToString()
        {
            return Message;
        }
    }

    class MathParser
    {
        //перчисляем типы лексем.
        enum Types { NONE, DELIMITER, VARIABLE, NUMBER };
        // Перечисляем типы ошибок.
        enum Errors { SYNTAX, UNBALPARENS, NOEXP, DIVBYZERO };

        string exp; // Ссылка на строку выражения,
        int expldx; // Текущий индекс в выражении,
        string token; // Текущая лексема.
        Types tokType; // Тип лексемы.

        // Массив для переменных,
        double[] vars = new double[26];

        public MathParser()
        {
            for (int i = 0; i < vars.Length; i++)
                vars[i] = 0.0;
        }

        // Входная точка анализатора.
        public double Evaluate(string expstr)
        {
            double result;
            exp = expstr;
            expldx = 0;

                GetToken();
                if (token == "")
                {
                    SyntaxErr(Errors.NOEXP);
                    return 0.0;
                }
                EvalExp1(out result);

                if (token != "")
                    SyntaxErr(Errors.SYNTAX);
            
                return result;
        }

        // Обрабатываем присвоение,
        void EvalExp1(out double result)
        {
            int varIdx;
            Types ttokType;
            string temptoken;
            if (tokType == Types.VARIABLE)
            {
                temptoken = String.Copy(token);
                ttokType = tokType;

                varIdx = Char.ToUpper(token[0]) - 'A';
                GetToken();
                if (token != "=")
                {
                    PutBack();

                    token = String.Copy(temptoken);
                    tokType = ttokType;
                }
                else
                {
                    GetToken();
                    EvalExp2(out result);
                    try
                    {
                        vars[varIdx] = result;
                    }
                    catch
                    {
                        SyntaxErr(Errors.SYNTAX);
                    }
                    return;
                }
            }

            EvalExp2(out result);
        }

        // Складываем или вычитаем два члена выражения.
        void EvalExp2(out double result)
        {
            string op;
            double partialResult;

            EvalExp3(out result);
            while ((op = token) == "+" || op == "-")
            {
                GetToken();
                EvalExp3(out partialResult);
                switch (op)
                {
                    case "-":
                        result = result - partialResult;
                        break;
                    case "+":
                        result = result + partialResult;
                        break;
                }
            }
        }

        // Выполняем умножение или деление двух множителей.
        void EvalExp3(out double result)
        {
            string op;
            double partialResult = 0.0;
            EvalExp4(out result);
            while ((op = token) == "*" || op == "/" || op == "%")
            {
                GetToken();
                EvalExp4(out partialResult);
                switch (op)
                {
                    case "*":
                        result = result * partialResult;
                        break;
                    case "/":
                        if (partialResult == 0.0)
                        {
                            SyntaxErr(Errors.DIVBYZERO);
                        }
                        result = result / partialResult;
                        break;
                    case "%":
                        if (partialResult == 0.0)
                        {
                            SyntaxErr(Errors.DIVBYZERO);
                        }
                        result = (int)result % (int)partialResult;
                        break;                     
                }
            }
        }

        // выполняем возведение в степень
        void EvalExp4(out double result)
        {
            double partialResult, ex;
            int t;
            EvalExp5(out result);
            if (token == "^")
            {
                GetToken();
                EvalExp4(out partialResult);
                ex = result;
                if (partialResult == 0.0)
                {
                    result = 1.0;
                    return;
                }
                for (t = (int)partialResult - 1; t > 0; t--)
                    result = result * (double)ex;
            }
        }

        // Выполненяем операцию унарного + или -.
        void EvalExp5(out double result)
        {
            string op;

            op = "";
            if ((tokType == Types.DELIMITER) && token == "+" || token == "-")
            {
                op = token;
                GetToken();
            }
            EvalExp6(out result);
            if (op == "-") result = -result;
        }

        // обрабатываем выражение в круглых скобках
        void EvalExp6(out double result)
        {
            if ((token == "("))
            {
                GetToken();
                EvalExp2(out result);
                if (token != ")")
                    SyntaxErr(Errors.UNBALPARENS);
                GetToken();
            }
            else Atom(out result);
        }
        // Получаем значение числа или переменной.
        void Atom(out double result)
        {
            switch (tokType)
            {
                case Types.NUMBER:
                    try
                    {
                        result = Double.Parse(token);
                    }
                    catch (FormatException)
                    {
                        result = 0.0;
                        SyntaxErr(Errors.SYNTAX);
                    }
                    GetToken();
                    return;
                case Types.VARIABLE:
                    result = FindVar(token);
                    GetToken();
                    return;
                default:
                    result = 0.0;
                    SyntaxErr(Errors.SYNTAX);
                    break;
            }
        }

        // Возвращаем значение переменной.
        double FindVar(string vname)
        {
            if (!Char.IsLetter(vname[0]))
            {
                SyntaxErr(Errors.SYNTAX);
                return 0.0;
            }
            try
            {
                return vars[Char.ToUpper(vname[0]) - 'A'];
            }
            catch
            {
                SyntaxErr(Errors.SYNTAX);
            }
            return 0;
        }

        // Возвращаем лексему во входной поток.
        void PutBack()
        {
            for (int i = 0; i < token.Length; i++) expldx--;
        }

        // Обрабатываем синтаксическую ошибку
        void SyntaxErr(Errors error)
        {
            string[] err = { "Синтаксическая ошибка","Дисбаланс скобок", "Выражение отсутствет", "Деление на 0" };
            throw new ParserException(err[(int)error]);
        }

        // получем следующую лексему.
        void GetToken()
        {
            tokType = Types.NONE;
            token = "";
            if (expldx == exp.Length)
            {
                return;
            }

            while (expldx < exp.Length && Char.IsWhiteSpace(exp[expldx])) ++expldx;

            if (expldx == exp.Length) return;
            if (IsDelim(exp[expldx]))
            {
                token += exp[expldx];
                expldx++;
                tokType = Types.DELIMITER;
            }
            else if (Char.IsLetter(exp[expldx]))
            {
                while (!IsDelim(exp[expldx]))
                {
                    token += exp[expldx];
                    expldx++;
                    if (expldx >= exp.Length) break;
                }
                tokType = Types.VARIABLE;
            }
            else if (Char.IsDigit(exp[expldx]))
            {
                while (!IsDelim(exp[expldx]))
                {
                    token += exp[expldx];
                    expldx++;
                    if (expldx >= exp.Length) break;
                }
                tokType = Types.NUMBER;
            }
        }
        // Метод возвращает значение true,
        // если с -- разделитель.
        bool IsDelim(char c)
        {
            if (("+-/*%^=()".IndexOf(c) != -1))
                return true;
            return false;
        }
    }
}
