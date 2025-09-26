# Dapper CRUD Operations - Blog Management System
A simple console application demonstrating CRUD (Create, Read, Update, Delete) operations using Dapper ORM with SQL Server.

## 📖 Overview
This project is a console-based application that performs basic CRUD operations on a blog database using Dapper, a lightweight ORM (Object-Relational Mapper) for .NET. The application implements soft delete functionality and provides a user-friendly menu-driven interface.

## ✨ Features
* Read Data: Display all active blog posts
* Create Data: Add new blog posts
* Update Data: Modify existing blog posts
* Delete Data: Soft delete blog posts (mark as deleted without removing from database)
* Input Validation: Basic validation for user inputs
* Error Handling: Proper error handling for database operations

## 🛠 Prerequisites
Before running this application, ensure you have:
* .NET 6.0 or later
* SQL Server (LocalDB or Express edition)
* Visual Studio 2022 or VS Code with C# extensions

## 🗄 Database Setup
1. Create a database named TrainingBatch5
2. Execute the following SQL script to create the required table:

        sql
        CREATE TABLE Tbl_Blog (
            BlogId INT IDENTITY(1,1) PRIMARY KEY,
            BlogTitle NVARCHAR(100) NOT NULL,
            BlogAuthor NVARCHAR(50) NOT NULL,
            BlogContent NVARCHAR(MAX) NOT NULL,
            DeleteFlag BIT NOT NULL DEFAULT 0
        );
   
## 📥 Installation
1. Clone the repository:

        bash
        git clone https://github.com/thetnaing-dh/DapperCRUD_Operation
        cd DapperCRUD
   
2. Update the connection string in DapperHelper.cs:

        csharp
        private readonly string _connectionString = "Your-Connection-String-Here";

3. Build the project:

        bash
        dotnet build
   
## 🚀 Usage
Run the application:

        bash
        dotnet run
        
## Menu Options:
* R: Read all active blog posts
* C: Create a new blog post
* U: Update an existing blog post
* D: Delete a blog post (soft delete)
* Any other key: Exit the application

## Example Workflow:
1. Press 'C' to create a new blog:

        text
        Enter Blog Title: Introduction to Dapper
        Enter Blog Author: John Doe
        Enter Blog Content: Dapper is a simple object mapper for .NET...

2. Press 'R' to view all blogs:

        text
        Id: 1, Title: Introduction to Dapper, Author: John Doe, Content: Dapper is a simple object mapper for .NET...  

3. Press 'U' to update a blog:

        text
        Enter Blog ID to Update: 1
        Enter New Blog Title: Getting Started with Dapper
        Enter New Blog Author: John Doe
        Enter New Blog Content: Updated content about Dapper...

4. Press 'D' to delete a blog:

        text
        Enter Blog ID to Delete: 1

## 📁 Project Structure
        text
        DapperCRUD/
        │
        ├── Models/
        │   └── BlogDataModel.cs
        ├── DapperHelper.cs
        ├── Program.cs
        └── DapperCRUD.csproj
## Key Files:
* Program.cs: Main entry point with user interface logic
* DapperHelper.cs: Contains all database operations using Dapper
* BlogDataModel.cs: Data model class representing blog structure

## 💻 Code Explanation
### BlogDataModel Class
        csharp
        public class BlogDataModel
        {
            public int BlogId { get; set; }
            public string BlogTitle { get; set; } = string.Empty;
            public string BlogAuthor { get; set; } = string.Empty;
            public string BlogContent { get; set; } = string.Empty;
        }

## Main Features:
1. Read Operation:
  * Retrieves all blogs where DeleteFlag = 0
  * Uses Query<BlogDataModel> for mapping results

2. Insert Operation:
  * Adds new blog with automatic DeleteFlag = 0
  * Uses parameterized queries for security

3. Update Operation:
  * Updates specific fields using ISNULL(NULLIF()) pattern
  * Only updates non-empty values
  * Checks existence before updating

4. Delete Operation:
  * Implements soft delete by setting DeleteFlag = 1
  * Verifies blog existence before deletion

## 🛠 Technologies Used
* .NET 6.0: Cross-platform development framework
* Dapper: Lightweight ORM for .NET
* SQL Server: Database management system
* System.Data.SqlClient: SQL Server data provider

## 🔧 Configuration
Update the connection string in DapperHelper.cs according to your environment:

        csharp
        private readonly string _connectionString = "Server=.;Database=TrainingBatch5;User Id=sa;Password=yourpassword;TrustServerCertificate=True;";

## 📝 Notes
* This implementation uses soft delete approach instead of physical deletion
* The application includes basic error handling but can be enhanced for production use
* Consider adding transaction support for complex operations
* Input validation can be improved with more robust checks

## 🤝 Contributing
Feel free to fork this project and submit pull requests for any improvements.

## 📄 License
This project is open source and available under the MIT License.
