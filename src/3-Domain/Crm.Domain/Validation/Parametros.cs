using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crm.Domain.Validation
{
    /// <summary>
    /// Classe com metodos auxiliares para validação de parametros nativos, objetos ou listas.
    /// </summary>
    public static class Parametros
    {
        /// <summary>
        /// Metodos que valida um objeto e seus campos.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto</typeparam>
        /// <param name="objectArgumentExpression">Objeto</param>
        public static void VerificarArgumento<T>(Expression<Func<T>> objectArgumentExpression) where T : class
        {
            GetDetails(objectArgumentExpression, out var argumentName, out var argumentValue);

            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Metodo que valida um IEnumerable de objetos, e se seus objetos estão corretamente preenchidos.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto</typeparam>
        /// <param name="stringArgumentExpression">Lista de Objetos</param>
        public static void VerificarArgumento<T>(IEnumerable<Expression<Func<T>>> stringArgumentExpression) where T : class
        {
            if (stringArgumentExpression == null)
            {
                throw new ArgumentNullException($"Value of the IEnumerable parameter \\ {nameof(stringArgumentExpression)} \\ cannot be null.");
            }

            foreach (var arguments in stringArgumentExpression)
            {
                GetDetails(arguments, out var argumentName, out var argumentValue);

                if (argumentValue == null)
                {
                    throw new ArgumentNullException(argumentName, $"Value of the IEnumerable parameter \\ {argumentName} \\ cannot be null, empty or only white-spaces.");
                }
            }
        }

        /// <summary>
        /// metodo que valida um argumento tipo string.
        /// </summary>
        /// <param name="stringArgumentExpression">Parametro para validação.</param>
        public static void VerificarArgumento(Expression<Func<string>> stringArgumentExpression)
        {
            GetDetails(stringArgumentExpression, out var argumentName, out var argumentValue);

            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentNullException(argumentName, $"Value of the parameter \\ {argumentName} \\ cannot be null, empty or only white-spaces.");
            }
        }

        /// <summary>
        /// Lista de argumentos tipo string.
        /// </summary>
        /// <param name="stringArgumentExpression">Parametro tipo IEnumerable de string.</param>
        public static void VerificarArgumento(IEnumerable<Expression<Func<string>>> stringArgumentExpression)
        {
            if (stringArgumentExpression == null)
            {
                throw new ArgumentNullException($"Value of the IEnumerable parameter \\ {nameof(stringArgumentExpression)} \\ cannot be null.");
            }

            foreach (var arguments in stringArgumentExpression)
            {
                GetDetails(arguments, out var argumentName, out var argumentValue);

                if (string.IsNullOrWhiteSpace(argumentValue))
                {
                    throw new ArgumentNullException(argumentName, $"Value of the IEnumerable parameter \\ {argumentName} \\ cannot be null, empty or only white-spaces.");
                }
            }
        }

        private static void GetDetails<T>
        (
            Expression<Func<T>> argumentExpression,
            out string paramName,
            out T paramValue
        )
            where T : class
        {
            var argumentBody = (MemberExpression)argumentExpression.Body;

            paramName = argumentBody.Member.Name;
            paramValue = argumentExpression.Compile().Invoke();
        }

        private static void GetDetails
        (
            Expression<Func<string>> argumentExpression,
            out string paramName,
            out string paramValue
        )
        {
            var argumentName = argumentExpression.ToString();

            var periodPosition = argumentName.LastIndexOf(".", StringComparison.InvariantCultureIgnoreCase);

            paramName
                = periodPosition != -1
                    ? argumentName.Substring(periodPosition + 1)
                    : "Desconhecido";

            paramValue = argumentExpression.Compile().Invoke();
        }
    }
}