using System;
using System.Text;
namespace ConsoleApp4
{
    namespace QueryBuildingFramework
    {
        class SQLQueryGeneratorProgram
        {
            static void Main(string[] args)
            {
                // Build a complex SQL query using fluent interface
                string query = new QueryBuilder()
                    .Select("Name, Age")
                    .From("Employees")
                    .Where("Department = 'IT' AND Age > 30")
                    .Build();

                Console.WriteLine("Generated SQL Query:");
                Console.WriteLine(query);
                Console.ReadKey();
            }
        }

        public class QueryBuilder
        {
            private StringBuilder _query;

            public QueryBuilder()
            {
                _query = new StringBuilder();
            }

            public QueryBuilder Select(string columns)
            {
                _query.Append($"SELECT {columns} ");
                return this;
            }

            public QueryBuilder From(string table)
            {
                _query.Append($"FROM {table} ");
                return this;
            }

            public QueryBuilder Where(string condition)
            {
                _query.Append($"WHERE {condition} ");
                return this;
            }

            public string Build()
            {
                return _query.ToString().Trim();
            }
        }

    }

}
