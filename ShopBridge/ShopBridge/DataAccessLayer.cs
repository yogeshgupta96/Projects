using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopBridge
{
    public class DataAccessLayer
    {
        public int? AddProduct(ShopBridgeProduct product)
        {
            int? primrayKey;
            try
            {
                using (ThinkBridgeDBEntities2 obj = new ThinkBridgeDBEntities2())
                {
                     primrayKey = obj.Generare_PK("ShopBridgeProducts").Single();
                    product.ProductId = (int)primrayKey;
                }

                using (ThinkBridgeDBEntities2 obj = new ThinkBridgeDBEntities2())
                {
                    obj.ShopBridgeProducts.Add(product);
                    obj.SaveChanges();
                }
            }

            catch (Exception e)
            {
                string msg = e.Message;
                string trace = e.StackTrace;
                throw (e);
            }
            return primrayKey;
        }
        public List<ShopBridgeProduct> GetAllProducts()
        {
            List<ShopBridgeProduct> data;
            try
            {

                using (ThinkBridgeDBEntities2 obj = new ThinkBridgeDBEntities2())
                {
                    data = obj.ShopBridgeProducts.ToList();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return data;
        }

        public List<ShopBridgeProduct> GetProduct(int ProdId)
        {
            List<ShopBridgeProduct> data;
            try
            {

                using (ThinkBridgeDBEntities2 obj = new ThinkBridgeDBEntities2())
                {
                    data = obj.ShopBridgeProducts.Where(x => x.ProductId == ProdId).ToList();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return data;
        }

        public void UpdateProduct(ShopBridgeProduct product)
        {
            try
            {
                using (ThinkBridgeDBEntities2 obj = new ThinkBridgeDBEntities2())
                {
                    var record = obj.ShopBridgeProducts.Where(x => x.ProductId == product.ProductId).Single();
                    record.Price = product.Price;
                    record.ProductDescription = product.ProductDescription;
                    record.Size = product.Size;
                    record.Brand = product.Brand;
                    record.Color = product.Color;
                    record.Category = product.Category;
                    obj.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public void DeleteProduct(int id)
        {
            try
            {

                using (ThinkBridgeDBEntities2 obj = new ThinkBridgeDBEntities2())
                {
                    var record = obj.ShopBridgeProducts.Where(x => x.ProductId == id).Single();
                    obj.ShopBridgeProducts.Remove(record);
                    obj.SaveChanges();
                }
            }
            catch(Exception e)
            {
                throw (e);
            }

        }

    }

}

