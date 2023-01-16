using Test.data.utils;
using System.Data.SqlClient;
using Test.domain.model;

internal class DataRepositoryImpl : DataRepository
{
    private DatabaseConfig databaseConfig = new DatabaseConfig();

    private SqlConnection? sqlConnection;
    private string errorMessage = "";

    public DataRepositoryImpl()
    {
        Response<SqlConnection> response = initSqlConnection();
        if (response is Response<SqlConnection>.Error)
        {
            errorMessage = ((Response<SqlConnection>.Error)response).message;
            sqlConnection = null;
            return;
        }
        this.sqlConnection = ((Response<SqlConnection>.Success)response).data;
    }

    public Response<List<ProductObject>> fetchData()
    {

        if (sqlConnection == null)
        {
            return new Response<List<ProductObject>>.Error(errorMessage);
        }

        string query = "SELECT DISTINCT id, type, product, idChild " +
            "FROM Объекты " +
            "JOIN Связи ON Объекты.id = Связи.idParent " +
            "WHERE Связи.idParent NOT IN (SELECT idChild FROM Связи)";

        List<ProductObject> productObjects = new List<ProductObject>();

        sqlConnection.Open();
        SqlDataReader reader = executeQuery(query);

        while (reader.Read())
            productObjects.Add(new ProductObject(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));

        sqlConnection.Close();

        return new Response<List<ProductObject>>.Success(productObjects);
    }

    private SqlDataReader executeQuery(string query)
    {

        SqlCommand command = sqlConnection.CreateCommand();
        command.CommandText = query;
        SqlDataReader reader = command.ExecuteReader();

        return reader;
    }

    public Response<List<ProductObject>> fetchData(List<int> childIds)
    {
        if (sqlConnection == null)
        {
            return new Response<List<ProductObject>>.Error(errorMessage);
        }

        string query = "SELECT DISTINCT idParent, type, product, idChild " +
            "FROM Объекты " +
            "JOIN Связи ON Объекты.id = Связи.idChild " +
            "WHERE ";

        for (int i = 0; i < childIds.Count; i++)
        {
            query = query + "Связи.idParent = " + childIds[i];
            if (i + 1 != childIds.Count)
                query = query + " OR ";
        }

        List<ProductObject> productObjects = new List<ProductObject>();

        sqlConnection.Open();

        SqlDataReader reader = executeQuery(query);

        while (reader.Read())
            productObjects.Add(new ProductObject(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));

        sqlConnection.Close();

        return new Response<List<ProductObject>>.Success(productObjects);
    }

    private Response<SqlConnection> initSqlConnection()
    {
        Response<SqlConnection> response = databaseConfig.getDatabaseInstance();
        return response;
    }

    public List<ProductObjectAtribute> fetchProductObjectAtributes(int productId)
    {
        sqlConnection.Open();
        string atributeQuery = "SELECT * FROM Атрибуты WHERE id = " + productId;
        SqlDataReader atributeReader = executeQuery(atributeQuery);
        List<ProductObjectAtribute> atributes = new List<ProductObjectAtribute>();
        while (atributeReader.Read())
            atributes.Add(new ProductObjectAtribute(atributeReader.GetInt32(0), atributeReader.GetString(1), atributeReader.GetString(2)));


        sqlConnection.Close();
        return atributes;
    }


    public int linkWithNewObject(int parentId, string type, string product, string linkName)
    {
        string query = "INSERT INTO Объекты(type, product) output INSERTED.ID VALUES(@type, @product)";

        SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("@type", type);
        command.Parameters.AddWithValue("@product", product);

        sqlConnection.Open();
        int id;
        try
        {
            id = (int)command.ExecuteScalar();

            string linkQuery = "INSERT INTO Связи (idParent, idChild, linkName) VALUES(@idParent, @idChild, @linkName)";
            command = new SqlCommand(linkQuery, sqlConnection);

            command.Parameters.AddWithValue("@idParent", parentId);
            command.Parameters.AddWithValue("@idChild", id);
            command.Parameters.AddWithValue("@linkName", linkName);

            command.ExecuteNonQuery();
        }
        catch
        {
            return -1;
        }

        sqlConnection.Close();
        return id;
    }

    public void deleteLink(int parentId)
    {
        string query = "WITH productStructure(idParent, idChild) AS (" +
            "SELECT idParent, idchild " +
            "FROM Связи " +
            $"WHERE idParent = ${parentId} " +
            "UNION ALL " +
            "SELECT links.idParent, links.idChild " +
            "FROM Связи links " +
            "INNER JOIN productStructure ps " +
            "ON ps.idChild = links.idParent) " +
            "DELETE FROM Связи WHERE " +
            "idParent IN (SELECT idParent FROM productStructure) " +
            $"DELETE FROM Связи WHERE idChild = ${parentId} ";

        SqlCommand command = new SqlCommand(query, sqlConnection);
        sqlConnection.Open();
        command.ExecuteNonQuery();
        sqlConnection.Close();
    }

    public List<ObjectItem> fetchObjectItems(int childId)
    {
        string query = "WITH productStructure(idParent, idChild) AS ( " +
            "SELECT idParent, idchild " +
            "FROM Связи " +
            "WHERE idChild = @childId " +
            "UNION ALL " +
            "SELECT links.idParent, links.idChild " +
            "FROM Связи links " +
            "INNER JOIN productStructure ps " +
            "ON ps.idParent = links.idChild) " +
            "SELECT id, type, product FROM Объекты " +
            "WHERE id <> @childId AND id NOT IN (SELECT idParent FROM productStructure)";

        SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("@childId", childId);
        sqlConnection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<ObjectItem> products = new List<ObjectItem>();
        while (reader.Read())
            products.Add(new ObjectItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));

        sqlConnection.Close();
        return products;
    }

    public bool linkWithExistingObject(int parentId, int childId, string linkName)
    {
        sqlConnection.Open();

        string linkQuery = "INSERT INTO Связи (idParent, idChild, linkName) VALUES(@idParent, @idChild, @linkName)";
        SqlCommand command = new SqlCommand(linkQuery, sqlConnection);

        command.Parameters.AddWithValue("@idParent", parentId);
        command.Parameters.AddWithValue("@idChild", childId);
        command.Parameters.AddWithValue("@linkName", linkName);

        try
        {
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        catch
        {
            return false;
        }
        return true;
    }
}

