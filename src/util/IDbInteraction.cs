using System.Reflection;
using src.Interaces;
using Microsoft.Data.SqlClient;
using Dapper;
using src.Utils.DbAttributes;

namespace src.Utils
{
    public abstract class IDbInteraction
    {
        private const string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True";

        //TODO    Unnecessary declaration of id
        // protected void CREATE_TABLE<T>(string name) where T : IDbObject
        // {
        //     using(SqlConnection connection= new SqlConnection(connectionString))
        //     {
        //         PropertyInfo[] properties  = typeof(T).GetProperties();

        //         string query = "CREATE TABLE " + name + " ( " ;

        //         bool findedId = false, primaryKeySetted = false;

        //         foreach(PropertyInfo prop in properties)
        //         {
        //             if(prop.Name.ToUpper() == "ID") findedId=true;

        //             Type type = prop.GetType();

        //             if(type == typeof(System.String))
        //             {
        //                 query += prop.Name +  $" varchar({prop.GetCustomAttribute<VarcharSizeAttribute>()?.size ?? 220}) ";
        //             }
        //             else if(type == typeof(int) || type.IsEnum) 
        //             {
        //                 query += prop.Name + " int ";
        //             }
        //             else if(type == typeof(DateTime)) 
        //             {
        //                 query += prop.Name + " date ";
        //             }
        //             else if(type == typeof(System.Boolean)) 
        //             {
        //                 query += prop.Name + " BIT ";
        //             }

        //             if(prop.GetCustomAttribute<NotNullAttribute>() != null)
        //                 query += "NOT NULL ";

        //             if(prop.GetCustomAttribute<PrimaryKeyAttribute>() != null && !primaryKeySetted)
        //             {
        //                 primaryKeySetted = true;
        //                 query += "PRIMARY KEY ";
        //             }


        //             query+=", ";
        //         }

        //         if(!findedId)
        //             query += "id int ";
                
        //         if(!primaryKeySetted)
        //         {
        //             //TODO deal with it
        //         }


        //         query += " );";
                
        //         connection.Execute(query);
        //     }
        // }

        protected void INSERT<T>(string table, T obj) where T : IDbObject
        {
            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                var res = obj.toDbInsert();
                string query = "INSERT INTO " + table + " " + res.keys + " VALUES " + res.values + ";";
            
                connection.Execute(query);
            }
        }

        protected IEnumerable<T> SELECT_ALL<T>(string table) where T : IDbObject
        {
            IEnumerable<T> List;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT * FROM " + table;
                List = connection.Query<T>(query);
            }

            return List;
        }

        protected T SELECT_EQUALS<T>(string table, int id) where T : IDbObject
        {
            T Obj;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT * FROM " + table + " where id="+ id;
                Obj = connection.QueryFirst<T>(query);
            }

            return Obj;
        }

        protected IEnumerable<T> SELECT_WHERE<T>(string table, string where) where T : IDbObject
        {
            IEnumerable<T> List;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM " + table + " WHERE " + where;
                List = connection.Query<T>(query);
            }

            return List;
        }

        protected void DELETE(string table, int id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "DELETE FROM " + table + " where id="+ id;
                connection.Execute(query);
            }
        }

        protected void UPDATE<T>(string table, T obj) where T : IDbObject
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "UPDATE " + table + " SET " + obj.toDbUpdate() + " WHERE id=" + obj.id();
                connection.Execute(query);
            }
        }
    }


}