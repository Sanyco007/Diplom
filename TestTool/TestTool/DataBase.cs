using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace TestTool
{
    public class DataBase
    {
        private readonly OleDbConnection _connection;

        private static DataBase _instance;

        public static DataBase GetInstance()
        {
            return _instance ?? (_instance = new DataBase());
        }

        private DataBase()
        {
            _connection = ConnectToDataBase();
        }

        private static OleDbConnection ConnectToDataBase()
        {
            const string connectionStrring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataBase\\test.accdb";
            var connection = new OleDbConnection(connectionStrring);
            return connection;
        }

        public DataTable SelectTable(string query)
        {
            _connection.Open();
            var dataAdapter = new OleDbDataAdapter
            {
                SelectCommand = new OleDbCommand(query, _connection)
            };
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }

        public bool AddTest(string title)
        {
            const string query = "INSERT INTO test (title, create_date) VALUES ('{0}', NOW());";
            _connection.Open();
            var insertQuery = new OleDbCommand(string.Format(query, title), _connection);
            var count = insertQuery.ExecuteNonQuery();
            _connection.Close();
            return count > 0;
        }

        public bool AddQuestion(int testId, string title, string type, string variants)
        {
            const string query = "INSERT INTO question (id_test, title, type, variants) VALUES ('{0}', '{1}', '{2}', '{3}');";
            _connection.Open();
            var insertQuery = new OleDbCommand(string.Format(query, testId, title, type, variants), _connection);
            var count = insertQuery.ExecuteNonQuery();
            _connection.Close();
            return count > 0;
        }

        public bool UpdateQuestion(int id, string title, string type, string variants)
        {
            const string query = "UPDATE question SET title='{0}', type='{1}', variants='{2}' WHERE `_id`={3};";
            _connection.Open();
            var insertQuery = new OleDbCommand(string.Format(query, title, type, variants, id), _connection);
            var count = insertQuery.ExecuteNonQuery();
            _connection.Close();
            return count > 0;
        }

        public void DeleteQuestion(int id)
        {
            const string query = "DELETE FROM question WHERE `_id`={0};";
            _connection.Open();
            var insertQuery = new OleDbCommand(string.Format(query, id), _connection);
            insertQuery.ExecuteNonQuery();
            _connection.Close();
        }

        public void ExportCvs(int testId, string fileName)
        {
            _connection.Open();
            const string query = "SELECT test.*, question.* FROM test, question WHERE test.`_id`={0} AND test.`_id` = question.id_test";
            var dataAdapter = new OleDbDataAdapter
            {
                SelectCommand = new OleDbCommand(string.Format(query, testId), _connection)
            };
            var dataTable = new DataSet();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            dataTable.WriteXml(fileName);
        }

        public bool AddAnswer(string id, string idQuestion, string text)
        {
            const string query = "INSERT INTO answer VALUES ('{0}', '{1}', '{2}');";
            _connection.Open();
            var insertQuery = new OleDbCommand(string.Format(query, id, idQuestion, text), _connection);
            var count = insertQuery.ExecuteNonQuery();
            _connection.Close();
            return count > 0;
        }

        public Dictionary<string, int> GetAnswer(int idQuestion, ref string type, ref string title)
        {
            const string query = "SELECT answer_text FROM answer WHERE id_question = {0}; ";
            var dict = new Dictionary<string, int>(); 
            _connection.Open();
            var insertQuery = new OleDbCommand(string.Format(query, idQuestion), _connection);
            var reader = insertQuery.ExecuteReader();
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    var text = reader.GetString(0);
                    string[] data = text.Split('~');
                    if (data.Length > 0)
                    {
                        foreach (var item in data)
                        {
                            if (!dict.ContainsKey(item))
                            {
                                dict.Add(item, 0);
                            }
                            dict[item]++;
                        }
                    }
                    else
                    {
                        if (!dict.ContainsKey(text))
                        {
                            dict.Add(text, 0);
                        }
                        dict[text]++;
                    }
                }
                reader.Close();
            }
            _connection.Close();
            const string queryQuestion = "SELECT title, type FROM question WHERE `_id` = {0}; ";
            _connection.Open();
            insertQuery = new OleDbCommand(string.Format(queryQuestion, idQuestion), _connection);
            reader = insertQuery.ExecuteReader();
            if (reader != null && reader.HasRows)
            {
                if (reader.Read())
                {
                    title = reader.GetString(0);
                    type = reader.GetString(1);
                }
                reader.Close();
            }
            _connection.Close();
            return dict;
        }

    }
}
