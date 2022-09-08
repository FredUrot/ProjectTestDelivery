using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ProjectTestDelivery.Models
{
    public class ApplicationDbContext
    {
        string connectionString = "Data Source = .;Initial Catalog=ProjectTestDelivery; User ID=sa;Password=123;";

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CustomerList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    DateTime cd = new DateTime();
                    var customer = new Customer();
                    customer.CustomerId = Convert.ToInt32(dr["CustomerId"].ToString());
                    customer.FirstName = dr["Firstname"].ToString();
                    customer.LastName = dr["Lastname"].ToString();
                    customer.Address = dr["Address"].ToString();
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out cd);
                    customer.CreatedDate = cd;
                    customerList.Add(customer);
                }
                conn.Close();
            }
            return customerList;
        }

        public void CreateCustomer(Customer customer)
        {
            var customerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CustomerInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", customer.LastName);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@CreatedDate", customer.CreatedDate);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CustomerUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@Firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", customer.LastName);
                cmd.Parameters.AddWithValue("@Address", customer.Address);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var customerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CustomerDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = new Customer();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CustomerById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime cd = new DateTime();
                    customer.CustomerId = Convert.ToInt32(dr["CustomerId"].ToString());
                    customer.FirstName = dr["Firstname"].ToString();
                    customer.LastName = dr["Lastname"].ToString();
                    customer.Address = dr["Address"].ToString();
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out cd);
                    customer.CreatedDate = cd;
                }
                conn.Close();
            }
            return customer;
        }

        public IEnumerable<Courier> GetAllCouriers()
        {
            var courierList = new List<Courier>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CourierList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime cd = new DateTime();
                    var courier = new Courier();
                    courier.CourierId = Convert.ToInt32(dr["CourierId"].ToString());
                    courier.FirstName = dr["Firstname"].ToString();
                    courier.LastName = dr["LastName"].ToString();
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out cd);
                    courier.CreatedDate = cd;
                    courierList.Add(courier);
                }
                conn.Close();
            }
            return courierList;
        }

        public void CreateCourier(Courier item)
        {
            var itemList = new List<Courier>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CourierInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", item.LastName);
                cmd.Parameters.AddWithValue("@CreatedDate", item.CreatedDate);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateCourier(Courier item)
        {
            var itemList = new List<Courier>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CourierUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CourierId", item.CourierId);
                cmd.Parameters.AddWithValue("@Firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", item.LastName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteCourier(int itemId)
        {
            var itemList = new List<Courier>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CourierDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CourierId", itemId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Courier GetCourier(int itemId)
        {
            var item = new Courier();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CourierById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CourierId", itemId);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime cd = new DateTime();
                    item.CourierId = Convert.ToInt32(dr["CourierId"].ToString());
                    item.FirstName = dr["Firstname"].ToString();
                    item.LastName = dr["LastName"].ToString();
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out cd);
                    item.CreatedDate = cd;
                }
                conn.Close();
            }
            return item;
        }

        public IEnumerable<Item> GetAllItems()
        {
            var itemList = new List<Item>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ItemList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime cd = new DateTime();
                    var item = new Item();
                    item.ItemId = Convert.ToInt32(dr["ItemId"].ToString());
                    item.CustomerId = Convert.ToInt32(dr["CustomerId"].ToString());
                    item.CourierId = Convert.ToInt32(dr["CourierId"].ToString());
                    item.ItemName = dr["ItemName"].ToString();
                    item.ItemDescription = dr["ItemDescription"].ToString();
                    item.Courier = new Courier();
                    item.Courier.CourierId = item.CourierId;
                    item.Courier.FirstName = dr["CourierFirstName"].ToString();
                    item.Courier.LastName = dr["CourierLastName"].ToString();
                    item.Customer = new Customer();
                    item.Customer.CustomerId = (int)item.CustomerId;
                    item.Customer.FirstName = dr["CustomerFirstName"].ToString();
                    item.Customer.LastName = dr["CustomerLastName"].ToString();
                    item.Customer.Address = dr["CustomerAddress"].ToString();
                    item.StatusType = Convert.ToInt32(dr["Status"].ToString());
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out cd);
                    item.CreatedDate = cd;
                    item.ProofName = dr["Proof"].ToString();
                    itemList.Add(item);
                }
                conn.Close();
            }
            return itemList;
        }

        public void CreateItem(Item item)
        {
            var itemList = new List<Item>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ItemInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourierId", item.CourierId);
                cmd.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmd.Parameters.AddWithValue("@Status", item.StatusType);
                cmd.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                cmd.Parameters.AddWithValue("@CreatedDate", item.CreatedDate);
                cmd.Parameters.AddWithValue("@Proof", item.ProofName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateItem(Item item)
        {
            var itemList = new List<Item>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ItemUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemId", item.ItemId);
                cmd.Parameters.AddWithValue("@CourierId", item.CourierId);
                cmd.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmd.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                cmd.Parameters.AddWithValue("@Status", item.StatusType);
                cmd.Parameters.AddWithValue("@Proof", item.ProofName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteItem(int itemId)
        {
            var itemList = new List<Item>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ItemDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemId", itemId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Item GetItem(int itemId)
        {
            var item = new Item();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ItemById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemId", itemId);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime cd = new DateTime();
                    item.ItemId = Convert.ToInt32(dr["ItemId"].ToString());
                    item.CustomerId = Convert.ToInt32(dr["CustomerId"].ToString());
                    item.CourierId = Convert.ToInt32(dr["CourierId"].ToString());
                    item.ItemName = dr["ItemName"].ToString();
                    item.ItemDescription = dr["ItemDescription"].ToString();
                    item.StatusType = Convert.ToInt32(dr["Status"].ToString());
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out cd);
                    item.CreatedDate = cd;
                    item.ProofName = dr["Proof"].ToString();
                }
                conn.Close();
            }
            return item;
        }

        public Item AssignToCourier(int itemId, int courierId)
        {
            var item = new Item();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ItemAssignToCourier", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemId", itemId);
                cmd.Parameters.AddWithValue("@CourierId", courierId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return item;
        }
    }
}
