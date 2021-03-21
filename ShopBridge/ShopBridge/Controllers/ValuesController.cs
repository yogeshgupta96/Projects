using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<ShopBridgeProduct> GetAllProducts()
        {
            List<ShopBridgeProduct> productsList;

            DataAccessLayer obj = new DataAccessLayer();
            
            try
            {
                productsList = obj.GetAllProducts();
            }
            catch (Exception e)
            {
                ShopBridgeUserException ex = new ShopBridgeUserException("Error occurred while getting the products");
                throw (ex);
            }
            return productsList;
        }
        //public int? GetAllProducts()
        //{
        //    int? b;
        //    using (ThinkBridgeDBEntities1 a = new ThinkBridgeDBEntities1())
        //    {
        //         b = a.Generare_PK("ShopBridgeProducts").Single();

        //         }
        //    return b;
        //}
        // GET api/values/5
        public List<ShopBridgeProduct> GetProduct(int id)
        {
            List<ShopBridgeProduct> productsList;
            DataAccessLayer obj = new DataAccessLayer();
            try
            {
                productsList = obj.GetProduct(id);
            }
            catch (Exception e)
            {
                ShopBridgeUserException ex = new ShopBridgeUserException("Error occurred while getting the products");
                throw (ex);
            }
            return productsList;
        }

        // POST api/values
        public int? Post([FromBody] ShopBridgeProduct product)
        {
            int? key = 0;
            try
            {
                DataAccessLayer obj = new DataAccessLayer();
                key=obj.AddProduct(product);
                return key;
            }
            catch(Exception e)
            {
                ShopBridgeUserException ex = new ShopBridgeUserException("Error occurred while inerting the product");
                throw (ex);
            }
        }

        // PUT api/values/5
        public string Put([FromBody] ShopBridgeProduct product)
        {
            string msg = "";
            try
            {
                DataAccessLayer obj = new DataAccessLayer();
                obj.UpdateProduct(product);
                msg = "Product has been updated successfully";
            }
            catch (Exception e)
            {
                ShopBridgeUserException ex = new ShopBridgeUserException("Error occurred while updating the product");
                throw (ex);

            }
            return msg;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string msg = "";
            try
            {
                DataAccessLayer obj = new DataAccessLayer();
                obj.DeleteProduct(id);
                msg = "Product has been deleted successfully";
            }
            catch (Exception e)
            {
                ShopBridgeUserException ex = new ShopBridgeUserException("Error occurred while deleting the product");
                throw (ex);

            }
            return msg;
        }
    }
}
