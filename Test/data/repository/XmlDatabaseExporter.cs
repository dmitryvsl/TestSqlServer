using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Test.data.utils;
using Test.domain.model;
using Test.domain.repository;

namespace Test.data.repository
{
    internal class XmlDatabaseExporter : DatabaseExporter
    {

        private DatabaseConfig databaseConfig = new DatabaseConfig();

        public void export(string filePath)
        {
            Response<SqlConnection> response = databaseConfig.getDatabaseInstance();
            if (response is Response<SqlConnection>.Error) return;
            SqlConnection connection = ((Response<SqlConnection>.Success)response).data;
            string query = "WITH productStructure(idParent, idChild, type, product) AS (" +
                "SELECT idParent, idchild,  type, product " +
                "FROM Связи " +
                "JOIN Объекты ON Объекты.id = Связи.idChild " +
                "UNION ALL " +
                "SELECT links.idParent, links.idChild, ps.product, ps.type " +
                "FROM Связи links " +
                "JOIN productStructure ps ON ps.idParent = links.idChild " +
                "JOIN Атрибуты ON Атрибуты.id = ps.idChild) " +
                "SELECT * FROM productStructure";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            XmlTextWriter textWriter = new XmlTextWriter(filePath, Encoding.UTF8);
            textWriter.Formatting = Formatting.Indented;
            textWriter.Indentation = 4;
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Объекты");

            int previousChildId = -1;
            int closeElementCount = 0;
            int level = 0;
            List<int> treeObjectIds = new List<int>();

            while (reader.Read())
            {
                int parentId = reader.GetInt32(0);
                int childId = reader.GetInt32(1);
                string type = reader.GetString(2).Replace(" ", "");
                string product = reader.GetString(3).Replace(" ", "");

                if (previousChildId != parentId)
                {
                    for (int i = 0; i < closeElementCount; i++) textWriter.WriteEndElement();
                    level -= closeElementCount;
                    closeElementCount = 0;
                }

                if (!treeObjectIds.Contains(parentId))
                {
                    if (previousChildId != -1) textWriter.WriteEndElement();
                    level = 0;
                    treeObjectIds.Clear();
                }

                if (level == 0)
                {
                    string parentObjectQuery = "SELECT id, type, product FROM Объекты WHERE id = @parentId";
                    SqlCommand parentObjectCommand = new SqlCommand(parentObjectQuery, connection);
                    parentObjectCommand.Parameters.AddWithValue("@parentId", parentId);
                    SqlDataReader parentObjectReader = parentObjectCommand.ExecuteReader();
                    while (parentObjectReader.Read())
                    {
                        textWriter.WriteStartElement(parentObjectReader.GetString(2).Replace(" ", ""));
                        textWriter.WriteElementString("id", parentObjectReader.GetInt32(0).ToString());
                        textWriter.WriteElementString("type", parentObjectReader.GetString(1).Replace(" ", ""));
                    }
                    level++;
                    treeObjectIds.Add(parentId);
                }

                textWriter.WriteStartElement(product);
                textWriter.WriteElementString("id", childId.ToString());
                textWriter.WriteElementString("type", type);

                string attributeQuery = "SELECT id, name, value FROM Атрибуты WHERE id = @id";
                SqlCommand attributeCommand = new SqlCommand(attributeQuery, connection);
                attributeCommand.Parameters.AddWithValue("@id", childId);
                SqlDataReader attributeReader = attributeCommand.ExecuteReader();
                while (attributeReader.Read())
                    textWriter.WriteElementString(attributeReader.GetString(1), attributeReader.GetString(2));

                closeElementCount++;
                level++;

                previousChildId = childId;
                treeObjectIds.Add(childId);
            }

            textWriter.WriteEndElement();
            textWriter.Close();
            connection.Close();
        }
    }
}
