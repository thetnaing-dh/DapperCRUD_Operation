using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using DapperCRUD.Models;

namespace DapperCRUD
{
    public class DapperHelper
    {
        private readonly string _connectionString = "Server=.;Database=TrainingBatch5;User Id=sa;Password=23032106;TrustServerCertificate=True;";

        public void ReadData()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Tbl_Blog WHERE DeleteFlag = 0";
                IEnumerable<BlogDataModel>? list= db.Query<BlogDataModel>(query).ToList();
                foreach (BlogDataModel item in list)
                {
                    Console.WriteLine($"Id: {item.BlogId}, Title: {item.BlogTitle}, Author: {item.BlogAuthor}, Content: {item.BlogContent}");
                }
            }
        }

        public void InsertData(BlogDataModel dto)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Tbl_Blog (BlogTitle, BlogAuthor, BlogContent, DeleteFlag) 
                                VALUES (@BlogTitle, @BlogAuthor, @BlogContent, 0)";
                int result = db.Execute(query, dto);
                Console.WriteLine(result > 0 ? "Insert Successful" : "Insert Failed");
            }
        }

        public void UpdateData(BlogDataModel dto)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string checkQuery = "SELECT COUNT(1) FROM Tbl_Blog WHERE BlogId = @BlogId AND DeleteFlag = 0";
                int count = db.ExecuteScalar<int>(checkQuery, new { dto.BlogId });
                if (count == 0)
                {
                    Console.WriteLine("Blog not found or has been deleted.");
                    return;
                }
                string query = @"UPDATE Tbl_Blog SET BlogTitle = ISNULL(NULLIF(@BlogTitle, ''), BlogTitle),
                                 BlogAuthor = ISNULL(NULLIF(@BlogAuthor, ''), BlogAuthor),
                                 BlogContent = ISNULL(NULLIF(@BlogContent, ''), BlogContent)
                                WHERE BlogId = @BlogId AND DeleteFlag = 0";
                int result = db.Execute(query, dto);
                Console.WriteLine(result > 0 ? "Update Successful" : "Update Failed");
            }
        }

        public void DeleteData(BlogDataModel dto) {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string checkQuery = "SELECT COUNT(1) FROM Tbl_Blog WHERE BlogId = @BlogId AND DeleteFlag = 0";
                int count = db.ExecuteScalar<int>(checkQuery, new { dto.BlogId });
                if (count == 0)
                {
                    Console.WriteLine("Blog not found or has been deleted.");
                    return;
                }
                string query = @"UPDATE Tbl_Blog 
                                SET DeleteFlag = 1 
                                WHERE BlogId = @BlogId AND DeleteFlag = 0";
                int result = db.Execute(query, dto);
                Console.WriteLine(result > 0 ? "Delete Successful" : "Delete Failed");
            }
        }
    }
}